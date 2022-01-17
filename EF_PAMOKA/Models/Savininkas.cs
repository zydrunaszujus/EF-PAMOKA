using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_PAMOKA.Models
{
   
    public class Savininkas { 
        
       [Key]
        public int Id { get; set; }
        public string Vardas{ get; set; }
    }
}
