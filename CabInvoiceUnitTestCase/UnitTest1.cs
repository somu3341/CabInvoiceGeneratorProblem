using CabInvoiceGeneratorProblem;

namespace CabInvoiceUnitTestCase
{
    public class Tests
    {
        public CabInvoiceGenerator cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldreturnTotalfare()
        {
            double totalFare = this.cabInvoiceGenerator.CalculateFare(3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturn_MinimumFare()
        {
            double totalFare = this.cabInvoiceGenerator.CalculateFare(0.2, 2.0);
            Assert.AreEqual(5.0, totalFare);
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldreturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(60.0, invoiceSummary.totalFare);
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldreturInvoiceSummary()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            InvoiceSummary expectedSummaery = new InvoiceSummary(60.0, 2);
            Assert.AreEqual(expectedSummaery, invoiceSummary);
        }
        [Test]
        public void GivenUserIdForMultipleRides_WhenProper_ShouldReturn_InvoiceSummary()
        {
            CabInvoiceGenerator repository = new CabInvoiceGenerator();
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            repository.MapRidesToUser("somu", ride);
            InvoiceSummary summary = repository.GetInvoiceSummary("somu");
            Assert.AreEqual(summary.totalFare, 60.0);
        }
        [Test]
        public void GivenRideOptionPremium_WhenProper_ShouldReturn_InvoiceSummary()
        {
            RideOption rideOption = new RideOption();
            RideOption result = rideOption.SetRideValue(RideOption.RideTypes.PREMIUM);
            double fare = this.cabInvoiceGenerator.CalculateFare(result.costPerKms, result.costPerMinute, result.minimumFare, 3.0, 2.0);
            Assert.AreEqual(fare, 49.0);
        }
        [Test]
        public void GivenRideOptionNormal_WhenProper_ShouldReturn_InvoiceSummary()
        {
            RideOption rideOption = new RideOption();
            RideOption result = rideOption.SetRideValue(RideOption.RideTypes.NORMAL);
            double fare = this.cabInvoiceGenerator.CalculateFare(result.costPerKms, result.costPerMinute, result.minimumFare, 3.0, 2.0);
            Assert.AreEqual(fare, 32.0);
        }
    }
}