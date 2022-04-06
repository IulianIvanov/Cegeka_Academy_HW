using System.Collections.Generic;

namespace RentalCars
{
    public class Customer
    {
        public string Name { get; }

        public int FrequentRenterPoints { get; set; }

        public List<Rental> Rentals { get; } = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }
        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}