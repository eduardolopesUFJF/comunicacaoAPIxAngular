using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();
            
            var hostUrl = configuration["hosturl"];

            if (string.IsNullOrEmpty(hostUrl))
                hostUrl = "http://0.0.0.0:11989";

            BuildWebHost(args,configuration,hostUrl).Run();
        }

        public static IWebHost BuildWebHost(string[] args, IConfigurationRoot configuration, string hostUrl) =>

            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls(hostUrl)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .Build();
    }
}
