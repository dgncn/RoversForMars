using RoversForMars.Domain.Surfaces;

namespace RoversForMars.Domain.Plateaus
{
    public class Plateau : Surface
    {
        public Plateau(int upper, int right) : base()
        {
            base.UpperCoordinate = upper;
            base.RightCoordinate = right;
        }
    }
}
