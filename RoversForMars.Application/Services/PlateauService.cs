using RoversForMars.Application.Interfaces;
using RoversForMars.Domain.Plateaus;
using System;
using static RoversForMars.Domain.Core.Messages;

namespace RoversForMars.Application.Services
{
    public class PlateauService : IPlateauService
    {
        public Plateau CreatePlateau()
        {
            int defaultValue = default, rightMaxForPlateau = default, upperMaxForPlateau = default;
            string coordinateAdressesForPlateau = Console.ReadLine();
            string[] coordinateArray = coordinateAdressesForPlateau.Split(' ');

            if (coordinateArray.Length <= 1)
            {
                Console.WriteLine(ErrorMessages.InvalidCoordinationValuesForMars);
                return null;
            }

            if (int.TryParse(coordinateArray[0], out defaultValue))
            {
                upperMaxForPlateau = defaultValue;
            }
            if (int.TryParse(coordinateArray[1], out defaultValue))
            {
                rightMaxForPlateau = defaultValue;
            }

            if (upperMaxForPlateau == 0 || rightMaxForPlateau == 0)
            {
                Console.WriteLine(ErrorMessages.InvalidCoordinationValuesForMars);
                return null;
            }
            Plateau newPlateau = new Plateau(upperMaxForPlateau, rightMaxForPlateau);
            return newPlateau;
        }

    }
}
