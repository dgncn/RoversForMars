using RoversForMars.Domain.Plateaus;
using RoversForMars.Domain.Surfaces;

namespace RoversForMars.Application.Interfaces
{
    public interface IPlateauService
    {
        Plateau CreatePlateau(int xCoordinate = 0, int yCoordinate = 0);
        Surface ConvertToCoordinates();
    }
}
