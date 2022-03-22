using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProHub.Core.Dtos.Accounts;
using ProHub.Core.Dtos.Establishments;
using ProHub.Core.Services.Accounts;
using ProHub.Core.Services.Establishments;


namespace ProHub.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountServices _accountServices;
        private readonly IEstablishmentServices _establishmentServices;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountServices accountServices,
            ILogger<AccountController> logger,
            IMapper mapper,
            IEstablishmentServices establishmentServices)
        {
            _accountServices = accountServices;
            _logger = logger;
            _mapper = mapper;
            _establishmentServices = establishmentServices;
        }

        public async Task<IActionResult> Login()
        {
            //await _accountServices.AddRole("Administrator");

            //var accountDto = new AccountDto
            //{
            //    Email = "admin@gmail.com",
            //    Password = "Creative@1",
            //    EstablishmentId = 1,
            //    FirstName = "Mohammed",
            //    LastName = "Galal",
            //    IsActive = true,
            //    ExpiryDate = DateTime.UtcNow.AddYears(2),
            //    MobileNumber = "966542038618",
            //    ActivationDate = DateTime.UtcNow,
            //    WorkPhone = "0114565699",
            //}; 

            //var account = _mapper.Map<Account>(accountDto);
            //account.FeaturesJson = JsonConvert.SerializeObject(new FeaturesDto
            //{
            //    IsAttendance = true,
            //    IsDistribution = true,
            //    IsLocation = false,
            //    IsSales = true,
            //    IsSupport = false,
            //    UserCount = 10,
            //    ValidationMinutes = 60
            //});
            //account.UserName = accountDto.Email;
            //account.InsertDate = DateTime.Now;
            //await _accountServices.CreateUserAsync(account, new List<string> { "Administrator" }, accountDto.Password);

            // if (User?.Identity?.IsAuthenticated == true)

            return RedirectToAction("Index", "Establishment");
            //  return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {

            var account = await _accountServices.Login(model.Email, model.Password);

            return RedirectToAction("Establishment");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddRole()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDto model)
        {
            if (ModelState.IsValid)
            {
                await _accountServices.AddRole(model.RoleName);
            }
            return View();
        }


        [Authorize()]
        public async Task<IActionResult> Establishment()
        {
            //var model = await _establishmentServices.GetEstablishmentDtoList();
            //var establishmentDto = new EstablishmentDto
            //{
            //    Address = "Address Name",
            //    ArName = "Arabic Name",
            //    Description = "Establishment Description",
            //    EnName = "English Name",
            //    ExpiryDate = DateTime.Now.AddYears(+9),
            //    PhoneNumber = "055555555",
            //    FaxNumber = "022222222"
            //};
            //var establishment = _mapper.Map<Establishment>(establishmentDto);
            //await _establishmentServices.AddEstablishment(establishment);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Establishment(EstablishmentDto model)
        {
            if (ModelState.IsValid)
            {
                //  await _accountServices.AddEstablishment(model);

            }

            return View();
        }


        //public async Task<JsonResult> ListAccounts([FromBody] DtParameters dtParameters)
        //{
        //    var accounts = await _accountServices.AccountList(1);
        //    return Json(new DtResult<AccountDto> { Data = accounts });
        //}


        public async Task<IActionResult> List()
        {
            var model = await _accountServices.AccountList(1);

            //var establishmentDto = new EstablishmentDto
            //{
            //    Address = "Address Name",
            //    ArName = "Arabic Name",
            //    Description = "Establishment Description",
            //    EnName = "English Name",
            //    ExpiryDate = DateTime.Now.AddYears(+9),
            //    PhoneNumber = "055555555",
            //    FaxNumber = "022222222"
            //};
            //var establishment = _mapper.Map<Establishment>(establishmentDto);
            //await _establishmentServices.AddEstablishment(establishment);







            ////  await _accountServices.AddRole("Administrator");

            //var accountDto = new AccountDto
            //{
            //    Email = "admin2.@gmail.com",
            //    Password = "Creative@1",
            //    EstablishmentId = 1,
            //    FirstName = "Mohammed",
            //    LastName = "Galal",
            //    IsActive = true,
            //    ExpiryDate = DateTime.UtcNow.AddYears(2),
            //    MobileNumber = "966542038618",
            //    ActivationDate = DateTime.UtcNow,
            //    WorkPhone = "0114565699",

            //};

            //var account = _mapper.Map<Account>(accountDto);
            //account.FeaturesJson = JsonConvert.SerializeObject(new FeaturesDto
            //{
            //    IsAttendance = true,
            //    IsDistribution = true,
            //    IsLocation = false,
            //    IsSales = true,
            //    IsSupport = false,
            //    UserCount = 10,
            //    ValidationMinutes = 60
            //});
            //// account.UserName = accountDto.Email;
            ////account.InsertDate = DateTime.Now;

            //await _accountServices.CreateUserAsync(account, new List<string> { "Administrator" }, accountDto.Password);
            return View(model);
        }

    }
}
