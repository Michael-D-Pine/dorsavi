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

            var serviceProvider = new ServiceCollection()
                .AddHttpClient<ISensor, SensorService>();

            var service = host.Services.GetService<ISensor>();

            Random r = new Random((int)DateTime.Now.Ticks);

            int a = r.Next(1, 1000);
            int b = r.Next(1, 1000);

            Console.WriteLine($"Adding {a} and {b}");
            Console.WriteLine($"Result {service.AddUsingC(a, b)}");

            var owners = await service.GetCats();

            owners.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.name}, {o.age}, {o.gender}");
            });

            Console.ReadLine();
        }
    }
}
