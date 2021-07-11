using RoversForMars.Application.Services;
using Xunit;

namespace RoversForMars.Tests
{
    public class RoverTests
    {
        // case senaryosunun g�nderilen ilk �rne�inin test kodu
        [Fact]
        public void Should_Y_Coordinate_One_More_Number()
        {
            int xCoor = 5, yCoor = 5, roverXCoor = 1, roverYCoor = 2;
            RoverService roverService = new RoverService();
            PlateauService plateauService = new PlateauService();
            var plateau = plateauService.CreatePlateau(xCoor, yCoor);

            string roverCoordinates = string.Concat(roverXCoor, " ", roverYCoor, " ", "N");
            var rover = roverService.CreateRover(plateau, roverCoordinates);
            roverService.ExecuteDirections("LMLMLMLMM");
            Assert.True(rover.CoordinateY == roverYCoor + 1);
        }

        // Do�uya do�ru 3 ad�m gitmesi gerekti�inin kontrol�
        [Fact]
        public void Should_X_Coordinate_Three_More_Number()
        {
            int xCoor = 5, yCoor = 5, roverXCoor = 1, roverYCoor = 2;
            RoverService roverService = new RoverService();
            PlateauService plateauService = new PlateauService();
            var plateau = plateauService.CreatePlateau(xCoor, yCoor);
            string roverCoordinates = string.Concat(roverXCoor, " ", roverYCoor, " ", "E");
            var rover = roverService.CreateRover(plateau, roverCoordinates);
            roverService.ExecuteDirections("MMM");
            Assert.True(rover.CoordinateX == roverXCoor + 3);
        }

        // y�n yanl�� atand�ysa rover null d�nmeli
        [Fact]
        public void Should_Return_Null_If_Direction_NotExist()
        {
            int xCoor = 5, yCoor = 5, roverXCoor = 1, roverYCoor = 2;
            RoverService roverService = new RoverService();
            PlateauService plateauService = new PlateauService();
            var plateau = plateauService.CreatePlateau(xCoor, yCoor);
            string roverCoordinates = string.Concat(roverXCoor, " ", roverYCoor, " ", "T");
            var rover = roverService.CreateRover(plateau, roverCoordinates);
            Assert.True(rover == null);
        }
    }
}
