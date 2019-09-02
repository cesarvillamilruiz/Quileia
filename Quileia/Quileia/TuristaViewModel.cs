using Microsoft.AspNetCore.Mvc.Rendering;
using Quileia.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia
{
    public class TuristaViewModel:Turista
    {
        [Display(Name ="Ciudad")]
        public int TuristaId { get; set; }
        public IEnumerable<SelectListItem> Turistas { get; set; }

    }
}
