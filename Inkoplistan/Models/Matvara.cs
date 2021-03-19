using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inkoplistan.Models
{
    public class Matvara
    {
        public int ID { get; set;}
        public string name { get; set; }
        public int antal  { get; set; }
        public bool Inhandlad { get; set; }
        public string UserId { get; set; }

    }
}
