namespace MoscowSport.core
{
    public struct Location
    {
        public Location(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude {get;}
        public double Latitude {get;}
    }
}
