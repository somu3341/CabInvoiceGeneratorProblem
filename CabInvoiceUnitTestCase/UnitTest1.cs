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
            double invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(60.0, invoiceSummary);

        }
    }
}