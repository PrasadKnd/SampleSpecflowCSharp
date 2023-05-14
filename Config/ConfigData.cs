

using Microsoft.Extensions.Configuration;

namespace SampleSpecflowProject.Config
{
    public class ConfigData
    {
        static IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static string? Browser = config["Browser"];
        public static string? Device = config["Device"];
    }
}
