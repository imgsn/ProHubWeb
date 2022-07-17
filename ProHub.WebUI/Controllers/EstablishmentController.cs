using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProHub.Core.Dtos.Establishments;
using ProHub.Core.Services.Establishments;
using Microsoft.Extensions.Logging;

namespace ProHub.WebUI.Controllers
{
    public class EstablishmentController : BaseController
    {
        private readonly IEstablishmentServices _establishmentServices;
        private readonly ILogger<EstablishmentController> _logger;

        public EstablishmentController(
            IEstablishmentServices establishmentServices,
            ILogger<EstablishmentController> logger)
        {
            _establishmentServices = establishmentServices;
            _logger = logger;
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
