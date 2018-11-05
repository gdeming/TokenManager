using System.Collections.Generic;
using System.Windows.Forms;

namespace TokenManager
{
    internal class ProviderData
    {
        public ProviderData(string name)
        {
            Name = name;
            Enabled = true;
            HotKeys = Keys.None;
            Tokens = new List<string>();
        }

        public string Name { get;  }

        public bool Enabled { get; set; }

        public Keys HotKeys { get; set; }

        public List<string> Tokens { get;  }

        public string ExtractToken()
        {
            string result = "";
            if (Tokens.Count > 0)
            {
                result = Tokens[0];
                Tokens.RemoveAt(0);
            }
            return result;
        }

        public void UpdateTokens(List<string> tokens)
        {
            Tokens.Clear();
            Tokens.AddRange(tokens);
        }
    }
}
