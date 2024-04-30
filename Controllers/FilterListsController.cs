using DocumentFormat.OpenXml.Wordprocessing;
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
    public class FilterListsController : Controller
    {
        private readonly PersonalAccountContext _db;

        public FilterListsController(PersonalAccountContext db)
        {
            _db = db;
        }

        public IActionResult Index(string address, string name, int id, DateTime date)
        {
            IQueryable<PersonalAccount> personalAccounts = _db.PersonalAccounts.Include(u => u.Residents);
            string Name = "";
            if(date != DateTime.MinValue)
            {
                personalAccounts = personalAccounts.Where(p => p.StartDate.Date == date.Date);
            }
            
            if (!string.IsNullOrEmpty(address))
            {
                personalAccounts = personalAccounts.Where(p => p.Address.Contains(address));
                Name = address;
            }

            if (!string.IsNullOrEmpty(name))
            {
                personalAccounts = personalAccounts.Where(p => p.Residents.Any(r => r.Surname == name));
                Name = name;
            }
            if (id == 1)
            {
                personalAccounts = personalAccounts.Where(p => p.Residents.Count != 0);
            }
            else if (id == 2)
            {
                personalAccounts = personalAccounts.Where(p => p.Residents.Count == 0);
            }
            

            FilterListViewModel viewModel = new FilterListViewModel()
            {
                PersonalAccount = personalAccounts.ToList(),
                Name = Name
            };
            return View(viewModel);
        }

       
    }
}
