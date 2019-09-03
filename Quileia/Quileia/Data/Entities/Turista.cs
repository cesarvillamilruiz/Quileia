using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Entities
{
    public class Turista:IEntity
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name ="Nombre Completo")]
      
        public string NombreCompleto { get; set; }


        [Display(Name ="Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaDeNacimiento { get; set; }

        
        [Range(0,10000000000000,ErrorMessage ="Debe ser un valor entre {1} y {2}")]
        public string Identificacion { get; set; }

        [Display(Name ="Frecuencia de viaje")]
        [Range(0,15,ErrorMessage ="debe ser un vlor entre {1} y {2}")]
        public int FrecunciaDeViaje { get; set; }
        
        [Range(0,200000000,ErrorMessage ="Debe ser un valor entre {1} y {2}")]
        [Display(Name ="Presupuesto de viaje")]
        public double PresupuestoDeViaje { get; set; }
        public List<TuristaCiudad> TuristaCiudades { get; set; }


        [Display(Name =" Usa tarjeta?")]
        public bool UsaTarjeta { get; set; }

    }
}
