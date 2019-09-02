using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quileia.Data.Entities;
using Quileia.Data.Repositories;
using Quileia.Models;
using Quileia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quileia.Controllers
{
    public class TuristaController : Controller
    {
        private readonly ITuristaRepository turistaRepository;
        private readonly ICiudadRepository ciudadRepository;

        public TuristaController(
            ITuristaRepository turistaRepository,
            ICiudadRepository ciudadRepository)
        {
            this.turistaRepository = turistaRepository;
            this.ciudadRepository = ciudadRepository;
        }

        public IActionResult Index()
        {
            return View(this.turistaRepository.GetAll().OrderBy(n => n.NombreCompleto));
        }

        public IActionResult Create()
        {
            var model = new AddTuristViewModel
            {
                Ciudades = this.ciudadRepository.GetComboCiudad()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Turista turista)
        {
            if (ModelState.IsValid)
            {
                await this.turistaRepository.CreateAsync(turista);
                return RedirectToAction(nameof(Index));
            }

            return View(turista);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await this.turistaRepository.GetTuristaWithCiudadAsync(id.Value);
            if (turista == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("turistaId", id.Value);
            return View(turista);
        }

        public async Task<IActionResult> AddTuristCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await this.turistaRepository.GetByIdAsync(id.Value);
            if (turista == null)
            {
                return NotFound();
            }

            var model = new CiudadViewmodel
            {
                TuristaId = turista.Id,
                Ciudades = this.ciudadRepository.GetComboCiudad()
            };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AddTuristCity(CiudadViewmodel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.turistaRepository.AddCiudadAsync(model);
                return this.RedirectToAction("Details", new { id = model.TuristaId });
            }

            return this.View(model);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var turist = await this.turistaRepository.GetByIdAsync(id.Value);
            if (turist == null)
            {
                return NotFound();
            }

            await this.turistaRepository.DeleteAsync(turist);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await this.turistaRepository.GetByIdAsync(id.Value);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Turista turista)
        {
            if (ModelState.IsValid)
            {
                await this.turistaRepository.UpdateAsync(turista);
                return RedirectToAction(nameof(Index));
            }

            return View(turista);
        } 

        public async Task<IActionResult> DeleteCityFromTurisAsync(int? id)
        {
            var turis=HttpContext.Session.GetInt32("turistaId");
            var tuci = new TuristaCiudad
            {
                CiudadId = id.Value,
                TuristaId = turis.Value
            };
            var turistaId = await this.turistaRepository.DeleteCiudadAsync(tuci);
            return this.RedirectToAction("Details", new { id = turistaId });

        }
    }
}
