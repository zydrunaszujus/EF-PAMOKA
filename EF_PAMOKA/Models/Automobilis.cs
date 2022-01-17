using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_PAMOKA.Models
{
    public class Automobilis
    {
        [Key] //primary key pirminis raktas(kuris jungiasi su Savininkas 
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int? SavininkoId { get; set; }

    
    }
}
