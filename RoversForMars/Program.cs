using Microsoft.Extensions.DependencyInjection;
using RoversForMars.Application.Interfaces;
using RoversForMars.Application.Services;
using RoversForMars.Domain.Plateaus;
using RoversForMars.Domain.Rovers;
using System;

namespace RoversForMars
{
    class Program
    {
        static void Main(string[] args)
        {
            #region service dependency injection
            var serviceProvider = new ServiceProviderConstructor().ServiceProvider;

            var _plateauService = serviceProvider.GetService<IPlateauService>();
            var _roverService = serviceProvider.GetService<IRoverService>();
            var _ioService = serviceProvider.GetService<IOService>();
            #endregion

            Console.WriteLine(_ioService.GetSurfaceCoordinatesText());

            var surface = _plateauService.ConvertToCoordinates();

            Plateau newPlateau = _plateauService.CreatePlateau(surface.RightCoordinate, surface.UpperCoordinate);
            if (newPlateau == null)
                return;

            while (true)
            {
                Console.WriteLine(_ioService.GetLocationCoordinatesForRover());
                string coordinateAdressesForRover = Console.ReadLine();
                MarsRover newRover = _roverService.CreateRover(newPlateau, coordinateAdressesForRover);
                if (newRover == null)
                    return;

                Console.WriteLine(_ioService.GetDirectionForRover());

                string directionCoordinates = Console.ReadLine();

                //ifadeyi çalıştırır
                _roverService.ExecuteDirections(directionCoordinates);

                //son konumu ve yönü yazar
                _roverService.ShowLastLocation(newRover);
            }
        }

    }
}
