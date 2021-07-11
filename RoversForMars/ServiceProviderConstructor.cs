using Microsoft.Extensions.DependencyInjection;
using RoversForMars.Application.Interfaces;
using RoversForMars.Application.Services;

namespace RoversForMars
{
    public class ServiceProviderConstructor
    {
        private ServiceProvider _serviceProvider;

        public ServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set { _serviceProvider = value; }
        }

        public ServiceProviderConstructor()
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IPlateauService, PlateauService>()
                .AddScoped<IRoverService, RoverService>()
                .AddScoped<IOService>()
                .BuildServiceProvider();
        }
    }
}
