using backend.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBackendService(this IServiceCollection services)
        {
            //services.AddScoped<ISensor, SensorService>();
            services.AddHttpClient<SensorService>();
            //services.AddHttpClient();
            return services;
        }
    }
}
