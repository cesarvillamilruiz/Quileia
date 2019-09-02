using Microsoft.AspNetCore.Mvc;
using Quileia.Data.Entities;
using Quileia.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Controllers
{
    public class CiudadController : Controller
    {
        private readonly ICiudadRepository ciudadRepository;

        public CiudadController(ICiudadRepository ciudadRepository)
        {
            this.ciudadRepository = ciudadRepository;
        }

        public IActionResult Index()
        {
            return View(this.ciudadRepository.GetAll().OrderBy(n => n.NombreCiudad));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                await this.ciudadRepository.CreateAsync(ciudad);
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await this.ciudadRepository.GetCiudadWithTurist(id.Value);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await this.ciudadRepository.GetByIdAsync(id.Value);
            if (ciudad == null)
            {
                return NotFound();
            }

            await this.ciudadRepository.DeleteAsync(ciudad);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await this.ciudadRepository.GetByIdAsync(id.Value);

            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        [HttpPost]

        public async Task<IActionResult>Edit(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                await this.ciudadRepository.UpdateAsync(ciudad);
                return RedirectToAction(nameof(Index));
            }

            return View(ciudad);
        }
    }
}
