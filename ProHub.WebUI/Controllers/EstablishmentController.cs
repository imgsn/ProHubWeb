using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProHub.Domain.Dtos.Establishments;
using ProHub.Domain.Services.Establishments;

namespace ProHub.WebUI.Controllers
{
    public class EstablishmentController : Controller
    {
        private readonly IEstablishmentServices _establishmentServices;

        public EstablishmentController(IEstablishmentServices establishmentServices)
        {
            _establishmentServices = establishmentServices;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Titleeeeeeeeeeeeeeeeeeeeeeeeeeeee";
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EstablishmentDto model)
        {
            return View();
        }


    }
}
