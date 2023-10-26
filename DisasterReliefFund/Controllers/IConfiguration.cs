using System.Configuration;

namespace DisasterReliefFund.Controllers
{
    internal interface IConfiguration
    {
        ConfigurationSection GetSection(string v);
    }
}