using RoversForMars.Application.Interfaces;
using RoversForMars.Domain.Core;
using RoversForMars.Domain.Plateaus;
using RoversForMars.Domain.Rovers;
using System;
using static RoversForMars.Domain.Core.Messages;

namespace RoversForMars.Application.Services
{
    public class RoverService : IRoverService
    {
        private MarsRover _marsRover;

        public MarsRover MarsRover
        {
            get { return _marsRover; }
            set { _marsRover = value; }
        }

        public MarsRover CreateRover(Plateau newPlateau, string coordinateAdressesForRover)
        {
            string[] coordinateArrayForRover = coordinateAdressesForRover.Split(' ');
            if (coordinateArrayForRover.Length <= 2)
            {
                Console.WriteLine(ErrorMessages.InvalidLocationCoordinationValuesForRover);
                return null;
            }

            MarsRover newRover = new MarsRover();
            if (int.TryParse(coordinateArrayForRover[0], out int defaultCoordinateXForRover))
            {
                if (newPlateau.UpperCoordinate >= defaultCoordinateXForRover)
                {
                    newRover.CoordinateX = defaultCoordinateXForRover;
                }
                else
                {
                    Console.WriteLine(ErrorMessages.InvalidLocationCoordinationValuesForRover);
                    return null;
                }
            }

            if (int.TryParse(coordinateArrayForRover[1], out int defaultCoordinateYForRover))
            {
                if (newPlateau.UpperCoordinate >= defaultCoordinateYForRover)
                {
                    newRover.CoordinateY = defaultCoordinateYForRover;
                }
                else
                {
                    Console.WriteLine(ErrorMessages.InvalidLocationCoordinationValuesForRover);
                    return null;
                }
            }
            string directionValue = string.Empty;
            switch (coordinateArrayForRover[2])
            {
                case "N":
                    directionValue = "North";
                    break;
                case "S":
                    directionValue = "South";
                    break;
                case "E":
                    directionValue = "East";
                    break;
                case "W":
                    directionValue = "West";
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidDirectionForRover);
                    break;
            }
            if (string.IsNullOrEmpty(directionValue))
                return null;

            if (Enum.TryParse(typeof(DirectionEnum), directionValue, out object directionObject))
            {
                DirectionEnum directionEnum = (DirectionEnum)directionObject;
                newRover.RoverDirection = directionEnum;
            }

            _marsRover = newRover;
            return newRover;
        }

        /// <summary>
        /// Yön ataması için
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteDirections(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                ExecuteSingleCommand(command[i]);
            }
        }

        private void ExecuteSingleCommand(char character)
        {
            switch (character)
            {
                case 'M':
                    GoStraight();
                    break;
                case 'L':
                    ChangeDirectionToLeft();
                    break;
                case 'R':
                    ChangeDirectionToRight();
                    break;
                default:
                    Console.WriteLine("Uygun olmayan ifade!");
                    return;
            }
        }

        public void Move()
        {
            switch (_marsRover.RoverDirection)
            {
                case DirectionEnum.North:
                    _marsRover.CoordinateY = ++_marsRover.CoordinateY;
                    break;
                case DirectionEnum.East:
                    _marsRover.CoordinateX = ++_marsRover.CoordinateX;
                    break;
                case DirectionEnum.South:
                    _marsRover.CoordinateY = --_marsRover.CoordinateY;
                    break;
                case DirectionEnum.West:
                    _marsRover.CoordinateX = --_marsRover.CoordinateX;
                    break;
                default:
                    break;
            }
        }

        public void GoStraight()
        {
            this.Move();
        }

        public void ChangeDirectionToLeft()
        {
            switch (_marsRover.RoverDirection)
            {
                case DirectionEnum.North:
                    _marsRover.RoverDirection = DirectionEnum.West;
                    break;
                case DirectionEnum.East:
                    _marsRover.RoverDirection = DirectionEnum.North;
                    break;
                case DirectionEnum.South:
                    _marsRover.RoverDirection = DirectionEnum.East;
                    break;
                case DirectionEnum.West:
                    _marsRover.RoverDirection = DirectionEnum.South;
                    break;
                default:
                    break;
            }
        }

        public void ChangeDirectionToRight()
        {
            switch (_marsRover.RoverDirection)
            {
                case DirectionEnum.North:
                    _marsRover.RoverDirection = DirectionEnum.East;
                    break;
                case DirectionEnum.East:
                    _marsRover.RoverDirection = DirectionEnum.South;
                    break;
                case DirectionEnum.South:
                    _marsRover.RoverDirection = DirectionEnum.West;
                    break;
                case DirectionEnum.West:
                    _marsRover.RoverDirection = DirectionEnum.North;
                    break;
                default:
                    break;
            }
        }

        public string AbbrDirection(DirectionEnum directionEnum)
        {
            switch (directionEnum)
            {
                case DirectionEnum.North:
                    return "N";
                case DirectionEnum.East:
                    return "E";
                case DirectionEnum.South:
                    return "S";
                case DirectionEnum.West:
                    return "W";
                default:
                    return string.Empty;
            }
        }

        public void ShowLastLocation(MarsRover newRover)
        {
            var result = string.Concat(newRover.CoordinateX, " ", newRover.CoordinateY, " ", AbbrDirection(newRover.RoverDirection));
            Console.WriteLine(result);
        }
    }
}
