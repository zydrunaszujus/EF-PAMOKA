using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_PAMOKA.Models
{
    public class DaiktaiJson
    {
        public string Pavadinimas { get; set; }
        public int? SavininkoId { get; set; }
    }
}
