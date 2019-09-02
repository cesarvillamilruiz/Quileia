using Microsoft.AspNetCore.Mvc.Rendering;
using Quileia.Data.Entities;
using Quileia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Repositories
{
    public interface ITuristaRepository :IGenericRepository<Turista>
    {
        IEnumerable<SelectListItem> GetComboTurists();

        Task<Turista> GetTuristaWithCiudadAsync(int id);

        Task AddCiudadAsync(CiudadViewmodel model);
        Task<int> DeleteCiudadAsync(TuristaCiudad tuci);
      
    }
}
