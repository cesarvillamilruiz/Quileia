using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Entities
{
    public class TuristaCiudad
    {
        public int TuristaId { get; set; }
        public int CiudadId { get; set; }
        public Turista Turista { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
