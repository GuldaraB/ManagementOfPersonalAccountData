using ManagementOfPersonalAccountData.Models;
using ManagementOfPersonalAccountData.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfPersonalAccountData.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonalAccountContext _db;
        private readonly IValidationService _validationService;

        public HomeController(PersonalAccountContext db, IValidationService validationService)
        {
            _db = db;
            _validationService = validationService;
        }

        public IActionResult Index()
        {
            List<PersonalAccount> list = _db.PersonalAccounts.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonalAccount account)
        {
            if (_validationService.IsValid(account))
            {
                _db.PersonalAccounts.Add(account);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Данные не валидны");
        }

        [HttpGet]
        public IActionResult Delete(int personalAccountId)
        {
            var personalAccount = _db.PersonalAccounts.FirstOrDefault(t => t.Id == personalAccountId);
            if (personalAccount is null)
            {
                return BadRequest();
            }
            _db.PersonalAccounts.Remove(personalAccount);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Specification(PersonalAccount personalAccount)
        {
            var account = _db.PersonalAccounts.Include(u => u.Residents).ToList().FirstOrDefault(n => n.Id == personalAccount.Id);
            return View(account);
        }

        [HttpGet]
        public IActionResult Edit(int personalAccountId)
        {
            var account = _db.PersonalAccounts.Include(u => u.Residents).ToList().FirstOrDefault(p => p.Id == personalAccountId);

            return View(account);

        }
        [HttpPost]
        public IActionResult Edit(PersonalAccount personalAccountId)
        {
            var account = _db.PersonalAccounts.FirstOrDefault(p => p.Id == personalAccountId.Id);
            account.Address = personalAccountId.Address;
            account.EndDate = personalAccountId.EndDate;
            account.RoomArea = personalAccountId.RoomArea;
            if (account.StartDate < account.EndDate)
            {
                _db.PersonalAccounts.Update(account);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Данные не валидны");
        }

        [HttpGet]
        public IActionResult AddResident(int personalAccountId)
        {
            var account = _db.PersonalAccounts.Include(u => u.Residents).ToList().FirstOrDefault(p => p.Id == personalAccountId);
            var personalAccountResident = new PersonalAccountResidentVM()
            {
                PersonalAccount = account,
                PersonalAccountId = personalAccountId
            };

                return View(personalAccountResident);

        }

        [HttpPost]
        public IActionResult AddResident(PersonalAccountResidentVM personalAccountResidentVM)
        {
            var newResident = new Resident()
            {
                Surname = personalAccountResidentVM.Resident.Surname,
                Name = personalAccountResidentVM.Resident.Name,
                Fatherland = personalAccountResidentVM.Resident.Fatherland,
                PersonalAccountId = personalAccountResidentVM.PersonalAccountId
            };
            _db.Residents.Add(newResident);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
