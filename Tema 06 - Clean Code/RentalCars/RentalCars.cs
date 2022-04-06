using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class RentalCars
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        public string Name { get; }
        double priceRegular = 20;
        double pricePrermium = 30;
        double priceMini = 15;
        double priceLuxury = 70;
        double priceIncreasedBucharest = 0.33;
        double thisAmount;
        double totalAmount = 0;

        public RentalCars(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
        }
        public double CalculateDiscountPerFavouritePoints(int frequentRenterPoints,double thisAmount)
        {
            if (frequentRenterPoints >= 5)
            {
                thisAmount = thisAmount * 0.95;
            }
            return thisAmount;
        }
        public double CalculatePricePerPriceCode(PriceCode priceCode, int daysRented, int frequentRenterPoints, string location)
        {
            double thisAmount = 0;

            if (priceCode == PriceCode.Regular)
            {
                thisAmount += priceRegular * daysRented;
                if (daysRented > 2)
                    thisAmount += (daysRented - 2) * priceRegular * 0.75;
            }

            if (priceCode == PriceCode.Premium)
            {
                thisAmount += daysRented * pricePrermium;
            }

            if (priceCode == PriceCode.Mini)
            {
                thisAmount += priceMini * daysRented;
                if (daysRented > 3)
                    thisAmount += (daysRented - 3) * priceMini * 0.66;
            }

            if (priceCode == PriceCode.Luxury && frequentRenterPoints >= 3)
            {
                thisAmount += daysRented * priceLuxury;
            }
            else
            {
                //Console.WriteLine("Not enough Renter Points to rent a luxury car");
            }

            // we apply the increased prices from Bucharest
            if (location == "Bucuresti")
            {
                thisAmount += thisAmount * priceIncreasedBucharest;
            }

            return thisAmount;
        }
        public int UpdateFrequentRenterPoints(PriceCode priceCode, int daysRented)
        {
            int points = 1;
            if (priceCode == PriceCode.Premium && daysRented > 1)
            {
                points++;
            }

            return points;
        }

        public string DisplayInformationPerRental()
        {

            var record = "Rental Record for " + Name + "\n";
            record += "------------------------------\n";
            foreach (var each in _rentals)
            {
                // determines the amount for each line
                thisAmount = CalculatePricePerPriceCode(each.Car.PriceCode, each.DaysRented, each.Customer.FrequentRenterPoints, each.Location);

                // dosent aply the discount on luxury cars
                if (each.Car.PriceCode != PriceCode.Luxury)
                    thisAmount = CalculateDiscountPerFavouritePoints(each.Customer.FrequentRenterPoints, thisAmount);

                each.Customer.FrequentRenterPoints += UpdateFrequentRenterPoints(each.Car.PriceCode, each.DaysRented);

                record += each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + thisAmount + " EUR\n";
                totalAmount += thisAmount;
            }

            record += "------------------------------\n";
            record += "Total revenue " + totalAmount + " EUR\n";

            return record;
        }
        public string DisplayInformationPerPriceCode()
        {
            double totalRegular = 0;
            double totalPremium = 0;
            double totalMini = 0;
            double totalLuxury = 0;

            var record = "Rental Record for " + Name + "\n";
            record += "------------------------------\n";
            foreach (var each in _rentals)
            {
                // determines the amount for each line
                thisAmount = CalculatePricePerPriceCode(each.Car.PriceCode, each.DaysRented, each.Customer.FrequentRenterPoints, each.Location);

                // dosent aply the discount on luxury cars
                if (each.Car.PriceCode != PriceCode.Luxury)
                    thisAmount = CalculateDiscountPerFavouritePoints(each.Customer.FrequentRenterPoints, thisAmount);

                if (each.Car.PriceCode == PriceCode.Mini)
                    totalMini += thisAmount;
                if (each.Car.PriceCode == PriceCode.Regular)
                    totalRegular += thisAmount;
                if (each.Car.PriceCode == PriceCode.Premium)
                    totalPremium += thisAmount;
                if (each.Car.PriceCode == PriceCode.Luxury)
                    totalLuxury += thisAmount;

            }
            record += "Category" + "\t" + "Total Income\n";
            record += "Regular   " + "\t" + totalRegular + " EUR\n";
            record += "Premium   " + "\t" + totalPremium + " EUR\n";
            record += "Mini      " + "\t" + totalMini + " EUR\n";
            record += "Luxury   " + "\t" + totalLuxury + " EUR\n";

            record += "------------------------------\n";
            record += "Total revenue " + totalAmount + " EUR\n";

            return record;
        }
    }
}