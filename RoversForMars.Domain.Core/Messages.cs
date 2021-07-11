namespace RoversForMars.Domain.Core
{
    public static class Messages
    {
        public static class ErrorMessages
        {
            public static string InvalidCoordinationValuesForMars
            {
                get
                {
                    return "Yüzey koordinasyon değerleri uygun girilmelidir.";
                }
            }

            public static string InvalidLocationCoordinationValuesForRover
            {
                get
                {
                    return "Araç için koordinasyon değerleri uygun girilmelidir.";
                }
            }

            public static string InvalidDirectionForRover
            {
                get
                {
                    return "Araç için uygun yön girilmelidir!";
                }
            }
        }

        public static class QuestionMessages
        {
            public static string GetSurfaceCoordinates
            {
                get
                {
                    return "Yüzey genişliği için maksimum koordinat verilerini giriniz:";
                }
            }

            public static string GetLocationCoordinatesForRover
            {
                get
                {
                    return "Aracın lokasyon koordinatlarını giriniz:";
                }
            }

            public static string GetDirectionForRover
            {
                get
                {
                    return "Aracın gidiş koordinatlarını yön olarak giriniz:";
                }
            }
        }
    }
}
