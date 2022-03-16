using Tema_02.IService;
using Tema_02.Model;

namespace Tema_02.Service
{
    public class CarService : IGenericService<Car>
    {
        List<Car> _cars = new List<Car>();
        public CarService()
        {
            for (int i = 0; i < 10; i++)
            {
                _cars.Add(new Car(){
                CarId = i,
                Brand = "Brand" + i,
                Model = "Model" + i,
                EnginePower = 100 + i,
                FuelType = "Fuel" + i,
                AcquisitionDate = DateTime.Now,
                Price = 100*i
                });
            }
        }
        public List<Car> Delete(int id)
        {
            _cars.RemoveAll(x => x.CarId == id);
            return _cars;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetById(int id)
        {
            return _cars.Where(x=> x.CarId == id).SingleOrDefault();
        }

        public List<Car> Insert(Car item)
        {
            _cars.Add(item);
            return _cars;
        }
    }
}
