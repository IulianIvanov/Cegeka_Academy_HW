using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalsFromIasi();
            RentalsFromBucuresti();
        }
        public static void RentalsFromIasi()
        {
            RentalCars store = new RentalCars("Iasi Rentals");

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            store.AddRental(new Rental(customer1, new Car(PriceCode.Regular, "Ford Focus"), 2, "Iasi"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Regular, "Renault Clio"), 3, "Iasi"));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Premium, "BMW 330i"), 1, "Iasi"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 3, "Iasi"));
            store.AddRental(new Rental(customer2, new Car(PriceCode.Mini, "Toyota Aygo"), 2, "Iasi"));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Mini, "Hyundai i10"), 4, "Iasi"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 2, "Iasi"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Mercedes E320"), 1, "Iasi"));

            Console.WriteLine(store.DisplayInformationPerRental());
            Console.WriteLine(store.DisplayInformationPerPriceCode());
            Console.ReadKey();
        }
        public static void RentalsFromBucuresti()
        {
            RentalCars store = new RentalCars("Bucuresti Rentals");

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            store.AddRental(new Rental(customer1, new Car(PriceCode.Regular, "Ford Focus"), 2, "Bucuresti"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Regular, "Renault Clio"), 3, "Bucuresti"));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Premium, "BMW 330i"), 1, "Bucuresti"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 3, "Bucuresti"));
            store.AddRental(new Rental(customer2, new Car(PriceCode.Mini, "Toyota Aygo"), 2, "Bucuresti"));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Mini, "Hyundai i10"), 4, "Bucuresti"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 2, "Bucuresti"));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Mercedes E320"), 1, "Bucuresti"));

            Console.WriteLine(store.DisplayInformationPerRental());
            Console.WriteLine(store.DisplayInformationPerPriceCode());
            Console.ReadKey();
        }
    }
}
