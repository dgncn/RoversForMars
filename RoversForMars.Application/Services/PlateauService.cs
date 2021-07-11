using RoversForMars.Application.Interfaces;
using RoversForMars.Domain.Plateaus;
using RoversForMars.Domain.Surfaces;
using System;
using static RoversForMars.Domain.Core.Messages;

namespace RoversForMars.Application.Services
{
    public class PlateauService : IPlateauService
    {
        public Plateau CreatePlateau(int xCoordinate = 0, int yCoordinate = 0)
        {
            if (xCoordinate == 0 || yCoordinate == 0)
            {
                Console.WriteLine(ErrorMessages.InvalidCoordinationValuesForMars);
                return null;
            }
            Plateau newPlateau = new Plateau(xCoordinate, yCoordinate);
            return newPlateau;
        }

        // girilen plato sol ve yukarı koordinat değerlerini rakamlara çevirir
        public Surface ConvertToCoordinates()
        {
            Surface surface = new Surface();
            string coordinateAdressesForPlateau = Console.ReadLine();
            string[] coordinateArray = coordinateAdressesForPlateau.Split(' ');

            if (coordinateArray.Length <= 1)
            {
                Console.WriteLine(ErrorMessages.InvalidCoordinationValuesForMars);
                return surface;
            }

            int defaultValue;
            if (int.TryParse(coordinateArray[0], out defaultValue))
            {
                surface.UpperCoordinate = defaultValue;
            }
            if (int.TryParse(coordinateArray[1], out defaultValue))
            {
                surface.RightCoordinate = defaultValue;
            }
            return surface;
        }

    }
}
