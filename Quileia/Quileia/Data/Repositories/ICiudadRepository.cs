using Microsoft.AspNetCore.Mvc.Rendering;
using Quileia.Data.Entities;
using Quileia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Repositories
{
    public interface ICiudadRepository:IGenericRepository<Ciudad>
    {
        IEnumerable<SelectListItem> GetComboCiudad();

        Task<Ciudad> GetCiudadWithTurist(int id);
    }
}
