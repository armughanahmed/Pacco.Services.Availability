using System.Threading.Tasks;
using Convey;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Pacco.Services.Availability.Application;
using Pacco.Services.Availability.Infrastructure.Mongo;

namespace Pacco.Services.Availability.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args).ConfigureServices(services =>
            services
            .AddConvey()
            .AddApplication()
            .Build()).Configure(app =>
            {
                app.UseInfrastructure();
            });
    }
}