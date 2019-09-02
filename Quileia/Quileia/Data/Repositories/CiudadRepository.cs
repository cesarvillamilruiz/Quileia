using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quileia.Data.Entities;
using Quileia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data.Repositories
{
    public class CiudadRepository:GenericRepository<Ciudad>,ICiudadRepository
    {
        private readonly ApplicationDbContext context;

        public CiudadRepository(ApplicationDbContext context)
            :base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboCiudad()
        {
            var list = this.context.Ciudades.Select(c => new SelectListItem
            {
                Text = c.NombreCiudad,
                Value = c.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(seleccione una ciudad)",
                Value = "0"
            });

            return list;
        }

       public async Task<Ciudad> GetCiudadWithTurist(int id)
        {
            return await this.context.Ciudades
                .Include(t => t.TuristaCiudades)
                .ThenInclude(u => u.Turista)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }


    }
}
