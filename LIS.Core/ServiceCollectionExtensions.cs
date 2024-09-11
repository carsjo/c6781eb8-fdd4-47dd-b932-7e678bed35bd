using LIS.Core.Interfaces;
using LIS.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LIS.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCalculator(this IServiceCollection services) 
            => services.AddTransient<ICalculator, Calculator>();
    }
}