using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tema_02.Model
{
    public class Car
    {
        public int CarId { get; set; }  
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int EnginePower { get; set; }
        public string FuelType { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AcquisitionDate { get; set; } = DateTime.Now;
        public double Price { get; set; }
        [Display(Name = "Costumer")]
        public int CostumerId { get; set; }
        public virtual Costumer Costumer { get; set; }
    }
}