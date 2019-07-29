using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TokenManager
{
    internal class TokenManagerModel
    {
        public TokenManagerModel()
        {
            if (Plaintext)
            {
                SettingsStore = LoadPlaintext<SettingsData>(SettingStoreFilePath);
                ProviderStore = LoadPlaintext<Dictionary<string, ProviderData>>(ProviderStoreFilePath);
            }
            else
            {
                SettingsStore = LoadEncrypted<SettingsData>(SettingStoreFilePath);
                ProviderStore = LoadEncrypted<Dictionary<string, ProviderData>>(ProviderStoreFilePath);
            }
        }

        public void Save()
        {
            if (Plaintext)
            {
                SavePlaintext(SettingsStore, SettingStoreFilePath);
                SavePlaintext(ProviderStore, ProviderStoreFilePath);
            }
            else
            {
                SaveEncrypted(SettingsStore, SettingStoreFilePath);
                SaveEncrypted(ProviderStore, ProviderStoreFilePath);
            }
        }

        public bool GetSettingsEnabled()
        {
            return SettingsStore.Enabled;
        }

        public void SetSettingsEnabled(bool enabled)
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

        public bool GetTokenAccessNotificationsEnabled()
        {
            return SettingsStore.TokenAccessNotificationsEnabled;
        }

        public void SetTokenAccessNotificationsEnabled(bool enabled)
        {
            SettingsStore.TokenAccessNotificationsEnabled = enabled;
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

        public string GetProviderUrl(string name)
        {
            string result = "";
            if (HasProvider(name))
            {
                result = ProviderStore[name].ProviderUrl;
            }
            return result;
        }

        public void SetProviderUrl(string name, string url)
        {
            if (HasProvider(name))
            {
                ProviderStore[name].ProviderUrl = url;
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

        private static T LoadPlaintext<T>(string filePath) where T : class, new()
        {
            T result = null;
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load file: \r\n    " + filePath, nameof(TokenManager));
                File.Move(filePath, filePath + "." + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
            return result ?? new T();
        }

        private static void SavePlaintext<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        private static T LoadEncrypted<T>(string filePath) where T : class, new()
        {
            T result = null;
            try
            {
                if (File.Exists(filePath))
                {
                    string encryptedString = File.ReadAllText(filePath);
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedString);
                    byte[] unencryptedBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
                    string unencryptedString = Encoding.UTF8.GetString(unencryptedBytes);
                    result = JsonConvert.DeserializeObject<T>(unencryptedString);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load file: \r\n    " + filePath, nameof(TokenManager));
                File.Move(filePath, filePath + "." + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
            return result ?? new T();
        }

        private static void SaveEncrypted<T>(T obj, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            string unencryptedString = JsonConvert.SerializeObject(obj);
            byte[] unencryptedBytes = Encoding.UTF8.GetBytes(unencryptedString);
            byte[] encryptedBytes = ProtectedData.Protect(unencryptedBytes, null, DataProtectionScope.CurrentUser);
            string encryptedString = Convert.ToBase64String(encryptedBytes);
            File.WriteAllText(filePath, encryptedString, Encoding.UTF8);
        }

        private static readonly bool Plaintext = Settings.Default.Plaintext;

        private static readonly string SettingStoreFileName = "TokenManager.settings";
        private static readonly string SettingStorePathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(TokenManager));
        private static readonly string SettingStoreFilePath = Path.Combine(SettingStorePathName, SettingStoreFileName);

        private static readonly string ProviderStoreFileName = "TokenManager.tokens";
        private static readonly string ProviderStorePathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(TokenManager));
        private static readonly string ProviderStoreFilePath = Path.Combine(ProviderStorePathName, ProviderStoreFileName);
    }
}
