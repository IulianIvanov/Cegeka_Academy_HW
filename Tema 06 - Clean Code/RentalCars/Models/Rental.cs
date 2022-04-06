

namespace RentalCars
{
    public class Rental
    {
        public int DaysRented { get; }
        public string Location { get; }
        public Customer Customer { get; }
        public Car Car { get; }

        public Rental(Customer customer, Car car, int daysRented,string location)
        {
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
            Location = location;
        }
    }
}