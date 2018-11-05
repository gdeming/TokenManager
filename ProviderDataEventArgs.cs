using System;
using System.Collections.Generic;

namespace TokenManager
{
    public class ProviderDataEventArgs
    {
        public ProviderDataEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
