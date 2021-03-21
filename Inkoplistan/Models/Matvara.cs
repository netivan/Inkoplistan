using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inkoplistan.Models
{
    public class Matvara
    {
        public int ID { get; set;}

        [DisplayName("ProduktNamn")]
        public string name { get; set; }
        public int antal  { get; set; }
        public bool Inhandlad { get; set; }
        public string UserId { get; set; }

       

    }
}
