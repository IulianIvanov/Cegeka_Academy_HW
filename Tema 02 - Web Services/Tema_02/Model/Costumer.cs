using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tema_02.Model
{
    public class Costumer
    {
        public int CostumerId { get; set; } = 1;
        public string Name { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; }
    }
}
