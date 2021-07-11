namespace RoversForMars.Domain.Surfaces
{
    /// <summary>
    /// Mars surface
    /// </summary>
    public class Surface
    {
        public int LowerCoordinate { get; set; } = 0;
        public int LeftCoordinate { get; set; } = 0;
        public int RightCoordinate { get; set; }
        public int UpperCoordinate { get; set; }
    }
}
