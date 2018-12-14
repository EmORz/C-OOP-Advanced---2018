namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int MediumAirplaneBaggageCompartments = 14;
        private const int MediumAirplaneSeats = 10;

        public MediumAirplane()
            : base(MediumAirplaneSeats, MediumAirplaneBaggageCompartments)
        {
        }
    }
}