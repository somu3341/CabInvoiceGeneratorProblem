namespace CabInvoiceGeneratorProblem
{
    public class CabInvoiceGenerator
    {
        public RideRepository rideRepository = new RideRepository();
        public static readonly double COST_PER_KILOMETER = 10.0;
        public static readonly double COST_PER_MINUTE = 1.0;
        public static readonly double MINIMUM_FARE = 5.0;
        public double cabFare = 0.0;
        public double CalculateFare(double distance, double time)
        {
            this.cabFare = (distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE);
            return Math.Max(this.cabFare, MINIMUM_FARE);
        }
    }
}