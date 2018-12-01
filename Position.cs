namespace GeoLocation
{
    public class Position
    {
        private double v1;
        private double v2;

        public Position(double v1, double v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
    }
}