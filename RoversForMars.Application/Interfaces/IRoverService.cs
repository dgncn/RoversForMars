using RoversForMars.Domain.Core;
using RoversForMars.Domain.Plateaus;
using RoversForMars.Domain.Rovers;

namespace RoversForMars.Application.Interfaces
{
    public interface IRoverService
    {
        MarsRover CreateRover(Plateau newPlateau, string directionCommand = "");
        void Move();
        void ExecuteDirections(string command);
        void GoStraight();
        void ChangeDirectionToLeft();
        void ChangeDirectionToRight();
        string AbbrDirection(DirectionEnum directionEnum);
        void ShowLastLocation(MarsRover newRover);
    }
}
