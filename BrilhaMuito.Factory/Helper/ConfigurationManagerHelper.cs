using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using BrilhaMuito.Factory.Helper.Interface;

namespace BrilhaMuito.Factory.Helper
{
    public class ConfigurationManagerHelper : IConfigurationManager
    {
        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;

        [DebuggerStepThrough]
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        [DebuggerStepThrough]
        public string GetProviderName(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ProviderName;
        }

    }
}