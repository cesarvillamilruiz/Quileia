using Microsoft.AspNetCore.Mvc;
using Quileia.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Controllers.API
{
    public class TursitasController:Controller
    {
        private readonly ITuristaRepository turistaRepository;

        public TursitasController(ITuristaRepository turistaRepository)
        {
            this.turistaRepository = turistaRepository;
        }

        [HttpGet]

        public IActionResult GetTurist()
        {
            return Ok(this.turistaRepository.GetAll());
        }
    }
}
