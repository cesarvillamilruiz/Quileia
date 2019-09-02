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
        public string NombreCompleto { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = true)]
        public DateTime? FechaDeNacimiento { get; set; }
        public string Identificacion { get; set; }
        public int FrecunciaDeViaje { get; set; }   
        public double PresupuestoDeViaje { get; set; }
        public List<TuristaCiudad> TuristaCiudades { get; set; }
        public bool UsaTarjeta { get; set; }

       
    }
}
