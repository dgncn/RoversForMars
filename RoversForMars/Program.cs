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
            var serviceProvider = new ServiceProviderConstructor().ServiceProvider;

            var _plateauService = serviceProvider.GetService<IPlateauService>();
            var _roverService = serviceProvider.GetService<IRoverService>();
            var _ioService = serviceProvider.GetService<IOService>();

            Console.WriteLine(_ioService.GetSurfaceCoordinatesText());

            Plateau newPlateau = _plateauService.CreatePlateau();
            if (newPlateau == null)
                return;

            while (true)
            {
                MarsRover newRover = _roverService.CreateRover(newPlateau);
                if (newRover == null)
                    return;

                Console.WriteLine(_ioService.GetDirectionForRover());

                string directionCoordinates = Console.ReadLine();

                //ifadeyi çalıştırır
                _roverService.ExecuteDirections(directionCoordinates);

                //son konumu ve yönü yazar
                Console.WriteLine(string.Concat(newRover.CoordinateX, " ", newRover.CoordinateY, " ", _roverService.AbbrDirection(newRover.RoverDirection)));
            }
        }

    }
}
