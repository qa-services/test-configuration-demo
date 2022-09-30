using Microsoft.Extensions.Configuration;
using QaServices.TestConfigurationDemoPart1.Models;
using Xunit.Abstractions;

namespace QaServices.TestConfigurationDemoPart1.Tests
{
    public class BasicConfigurationTests
    {
        private readonly ITestOutputHelper _output;

        public BasicConfigurationTests(ITestOutputHelper output) => _output = output;

        [Fact]
        public void TestUrlIsLoaded()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appSettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            Settings settings = new();

            configuration.Bind(settings);

            _output.WriteLine($"Url from config: {settings.Url}");

        }
    }
}