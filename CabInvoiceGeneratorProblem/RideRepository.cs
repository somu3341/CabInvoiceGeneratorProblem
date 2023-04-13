namespace CabInvoiceGeneratorProblem
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> userRideList = new Dictionary<string, List<Ride>>();
        public void AddCabRides(string userID, Ride[] rides)
        {
            bool checkList = this.userRideList.ContainsKey(userID);
            if (checkList == false)
            {
                this.userRideList.Add(userID, new List<Ride>(rides));
            }
        }
        public Ride[] GetCabRides(string userID)
        {
            return this.userRideList[userID].ToArray();
        }
    }
}