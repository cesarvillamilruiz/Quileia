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
    public class TuristaRepository:GenericRepository<Turista>,ITuristaRepository
    {
        private readonly ApplicationDbContext context;

        public TuristaRepository(ApplicationDbContext context)
            :base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboTurists()
        {
            var list = this.context.Turistas.Select(t => new SelectListItem
            {
                Text = t.NombreCompleto,
                Value = t.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un turista...)",
                Value = "0"
            });

            return list;
        }

        public async Task<Turista> GetTuristaWithCiudadAsync(int id)
        {
            return await this.context.Turistas
                .Include(c => c.TuristaCiudades)
                .ThenInclude(n=>n.Ciudad)               
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddCiudadAsync(CiudadViewmodel model)
        {
            var turista = await this.GetTuristaWithCiudadAsync(model.TuristaId);

            if (turista == null)
            {
                return;
            }


            var agregar = new TuristaCiudad();
            agregar.CiudadId= model.CiudadId;
            agregar.TuristaId = model.TuristaId;

            this.context.TuristaCiudades.Add(agregar);
            await this.context.SaveChangesAsync();
        }

        public async Task<Ciudad> GetCiudadAsync(int id)
        {
            return await this.context.Ciudades.FindAsync(id);
        }

        public async Task<int> DeleteCiudadAsync(TuristaCiudad tuci)
        {
            var turista = await this.context.TuristaCiudades
                .Include(i => i.Ciudad)
                .Include(o => o.Turista)
                .Where(k=>k.TuristaId==tuci.TuristaId)
                .FirstOrDefaultAsync();
              

            this.context.TuristaCiudades.Remove(turista);
            await this.context.SaveChangesAsync();
            return turista.TuristaId;
               
        }
    }
}
