using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Models
{
    public class CiudadViewmodel
    {
        [Display(Name ="Ciudad")]
        public int CiudadId { get; set; }
        public int TuristaId { get; set; }
        public IEnumerable<SelectListItem> Ciudades { get; set; }
    }
}
