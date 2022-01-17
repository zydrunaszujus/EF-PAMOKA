using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_PAMOKA.Models
{
    public class Daiktas
    {
        [Key]
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int? SavininkoId { get; set; }
   // ? reiskia,kad gali ir nebuti
    }   


}
