using static RoversForMars.Domain.Core.Messages;

namespace RoversForMars.Application.Services
{
    public class IOService
    {
        public string GetSurfaceCoordinatesText()
        {
            return QuestionMessages.GetSurfaceCoordinates;
        }

        public string GetDirectionForRover()
        {
            return QuestionMessages.GetDirectionForRover;
        }

        public string GetLocationCoordinatesForRover()
        {
            return QuestionMessages.GetLocationCoordinatesForRover;
        }
    }
}
