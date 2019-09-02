using Microsoft.AspNetCore.Mvc.Rendering;
using Quileia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.ViewModels
{
    public class AddTuristViewModel:Turista
    {
        public int CiudadId { get; set; }
        public IEnumerable<SelectListItem> Ciudades { get; set; }
    }
}
