using System.Collections.Specialized;

namespace BrilhaMuito.Factory.Helper.Interface
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        string GetConnectionString(string name);
        string GetProviderName(string name);
    }
}