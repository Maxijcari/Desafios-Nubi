using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Pais: Paises
    {
        public char decimal_separator { get; set; }
        public char thousands_separator { get; set; }
        public string time_zone { get; set; }
        public Location geo_information { get; set; }
        public List<States> states { get; set; }
    }
}
