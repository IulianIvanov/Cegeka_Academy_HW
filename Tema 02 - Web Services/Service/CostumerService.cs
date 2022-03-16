using Tema_02.IService;
using Tema_02.Model;

namespace Tema_02.Service
{
    public class CostumerService : IGenericService<Costumer>
    {
        List<Costumer> _costumer = new List<Costumer>();
        public CostumerService()
        {
            for (int i = 0; i < 10; i++)
            {
                _costumer.Add(new Costumer()
                {
                    CostumerId = i,
                    Name = "Name" + i,
                });
            }
        }
        public List<Costumer> Delete(int id)
        {
            _costumer.RemoveAll(x => x.CostumerId == id);
            return _costumer;
        }

        public List<Costumer> GetAll()
        {
            return _costumer;
        }
        public Costumer GetById(int id)
        {
            return _costumer.Where(x => x.CostumerId == id).SingleOrDefault();
        }

        public List<Costumer> Insert(Costumer item)
        {
            _costumer.Add(item);
            return _costumer;
        }
    }
}
