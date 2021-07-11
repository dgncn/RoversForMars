using RoversForMars.Domain.Core;
using RoversForMars.Domain.Vehicles;
using System;

namespace RoversForMars.Domain.Rovers
{
    /// <summary>
    /// Mars rover
    /// </summary>
    public class MarsRover : Vehicle
    {
        /// <summary>
        /// Direction values for Mars Rover in enum
        /// </summary>
        public DirectionEnum RoverDirection { get; set; }
    }
}
