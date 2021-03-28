using backend;
using backend.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder().ConfigureServices((services) =>
            {
                services.AddHttpClient<ISensor, SensorService>();
            }).Build();


           // await host.RunAsync();

            var serviceProvider = new ServiceCollection()
                .AddHttpClient<ISensor, SensorService>();
            //.BuildServiceProvider();

            var service = host.Services.GetService<ISensor>();

            //var service = serviceProvider. serviceProvider.GetService<ISensor>();

            Console.WriteLine(service.AddUsingC(1, 2));
            var owners = await service.GetCats();

            owners.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.name}, {o.age}, {o.gender}");
            });

            Console.ReadLine();
        }
    }
}
