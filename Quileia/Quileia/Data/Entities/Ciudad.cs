using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Entities
{
    public class Ciudad:IEntity
    {
        public int Id { get; set; }

        [Display(Name ="Ciudad")]
        [StringLength(50,ErrorMessage ="Maximo {1} caracteres")]

        public string NombreCiudad { get; set; }

        [Display(Name = "Numero de habitantes")]
        [Range(1,8000000,ErrorMessage ="minimo {1} habitante y maximo {2} habitantes")]
        public int CantidaddeHabitantes { get; set; }

        [Display(Name = "Lugar Turistico")]
        [StringLength(50, ErrorMessage = "Maximo {1} caracteres")]
        public string SitioTuristico { get; set; }

        [Display(Name = "Mejor hotel")]
        [StringLength(50, ErrorMessage = "Maximo {1} caracteres")]
        public string  HotelMasReservado { get; set; }
        public List<TuristaCiudad> TuristaCiudades { get; set; }
    }
}
