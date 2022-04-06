

namespace RentalCars
{
    public enum PriceCode
    {
        Regular,
        Premium,
        Mini, 
        Luxury
    }
    public class Car
    {
        public PriceCode PriceCode { get; } 
        public string Model { get; }
        public Car(PriceCode priceCode, string model)
        {
            PriceCode = priceCode;
            Model = model;
        }
    }
}