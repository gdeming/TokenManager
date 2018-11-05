using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TokenManager
{
    internal class TokenManagerModel
    {
        public TokenManagerModel()
        {
            SettingsStore = LoadSettingsState();
            ProviderStore = LoadProviderState();
        }

        public void Save()
        {
            SaveSettingsState(SettingsStore);
            SaveProviderState(ProviderStore);
        }

        public bool GetSettingsEnabled()
        {
            return SettingsStore.Enabled;
        }

        public void  SetSettingsEnabled(bool enabled)
        {
            SettingsStore.Enabled = enabled;
        }

        public Keys GetSettingsHotKeys()
        {
            return SettingsStore.HotKeys;
        }

        public void SetSettingsHotKeys(Keys hotKeys)
        {
            SettingsStore.HotKeys = hotKeys;
        }

        public int GetSettingsWarnAt()
        {
            return SettingsStore.WarnAt;
        }

        public void SetSettingsWarnAt(int warnAt)
        {
            SettingsStore.WarnAt = warnAt;
        }

        public bool HasProvider(string name)
        {
            return ProviderStore.ContainsKey(name);
        }

        public bool HasTokens(string name)
        {
            return HasProvider(name) && (TokenCount(name) > 0);
        }

        public int TokenCount(string name)
        {
            return HasProvider(name) ? ProviderStore[name].Tokens.Count : 0;
        }

        public List<string> GetProviderNames()
        {
            return ProviderStore.Keys.ToList();
        }

        public bool AddProvider(string name)
        {
            bool result = false;
            if (!HasProvider(name))
            {
                ProviderStore.Add(name, new ProviderData(name));
                ProviderAdded?.Invoke(this, new ProviderDataEventArgs(name));
                result = true;
            }
            return result;
        }

        public bool RemoveProvider(string name)
        {
            bool result = false;
            if (HasProvider(name))
            {
                ProviderStore.Remove(name);
                ProviderRemoved?.Invoke(this, new ProviderDataEventArgs(name));
                result = true;
            }
            return result;
        }

        public bool GetProviderEnabled(string name)
        {
            bool result = false;
            if (HasProvider(name))
            {
                result = ProviderStore[name].Enabled;
            }
            return result;
        }

        public void SetProviderEnabled(string name, bool enabled)
        {
            if (HasProvider(name))
            {
                ProviderStore[name].Enabled = enabled;
            }
        }

        public Keys GetProviderHotKeys(string name)
        {
            Keys result = Keys.None;
            if (HasProvider(name))
            {
                result = ProviderStore[name].HotKeys;
            }
            return result;
        }

        public void SetProviderHotKeys(string name, Keys hotKeysData)
        {
            if (HasProvider(name))
            {
                ProviderStore[name].HotKeys = hotKeysData;
            }
        }

        public bool SetProviderTokens(string name, List<string> tokens)
        {
            bool result = false;
            if (HasProvider(name))
            {
                ProviderStore[name].UpdateTokens(tokens);
                result = true;
            }
            return result;
        }

        public List<string> GetProviderTokens(string name)
        {
            List<string> result = null;
            if (HasProvider(name))
            {
                result = ProviderStore[name].Tokens;
            }
            return result ?? new List<string>();
        }

        public string ExtractProviderToken(string name)
        {
            string result = "";
            if (HasTokens(name))
            {
                result = ProviderStore[name].ExtractToken();
            }
            return result;
        }

        public EventHandler<ProviderDataEventArgs> ProviderAdded;

        public EventHandler<ProviderDataEventArgs> ProviderRemoved;

        private SettingsData SettingsStore { get; }

        private Dictionary<string, ProviderData> ProviderStore { get; }

        private static void SaveSettingsState(SettingsData settingsStore)
        {
            string json = JsonConvert.SerializeObject(settingsStore, Formatting.Indented);
            Directory.CreateDirectory(SettingsPathName);
            File.WriteAllText(SettingsFilePath, json, Encoding.UTF8);
        }

        private static SettingsData LoadSettingsState()
        {
            SettingsData result = null;
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string json = File.ReadAllText(SettingsFilePath);
                    result = JsonConvert.DeserializeObject<SettingsData>(json);
                }
            }
            catch
            {
                MessageBox.Show("Unable to parse settings file: \r\n    " + SettingsFilePath, "Token Manager");
                File.Move(SettingsFilePath, SettingsFilePath + "." + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
            return result ?? new SettingsData();
        }

        private static void SaveProviderState(Dictionary<string, ProviderData>providerStore)
        {
            string json = JsonConvert.SerializeObject(providerStore, Formatting.Indented);
            Directory.CreateDirectory(TokensPathName);
            File.WriteAllText(TokensFilePath, json, Encoding.UTF8);
        }

        private static Dictionary<string, ProviderData> LoadProviderState()
        {
            Dictionary<string, ProviderData> result = null;
            try
            {
                if (File.Exists(TokensFilePath))
                {
                    string json = File.ReadAllText(TokensFilePath);
                    result = JsonConvert.DeserializeObject<Dictionary<string, ProviderData>>(json);
                }
            }
            catch
            {
                MessageBox.Show("Unable to parse tokens file: \r\n    " + TokensFilePath, "Token Manager");
                File.Move(TokensFilePath, TokensFilePath + "." + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
            return result ?? new Dictionary<string, ProviderData>();
        }

        private static readonly string SettingsFileName = "TokenManager.settings";
        private static readonly string SettingsPathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TokenManager");
        private static readonly string SettingsFilePath = Path.Combine(SettingsPathName, SettingsFileName);

        private static readonly string TokensFileName = "TokenManager.tokens";
        private static readonly string TokensPathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TokenManager");
        private static readonly string TokensFilePath = Path.Combine(TokensPathName, TokensFileName);
    }
}
