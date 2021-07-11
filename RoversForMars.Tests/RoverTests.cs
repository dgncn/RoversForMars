using RoversForMars.Application.Services;
using Xunit;

namespace RoversForMars.Tests
{
    public class RoverTests
    {
        // case senaryosunun gönderilen ilk örneðinin test kodu
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

        // Doðuya doðru 3 adým gitmesi gerektiðinin kontrolü
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

        // yön yanlýþ atandýysa rover null dönmeli
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
