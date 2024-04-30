using System;
using System.Collections.Generic;

namespace ManagementOfPersonalAccountData.Models
{
    public class FilterListViewModel
    {
        public IEnumerable<PersonalAccount> PersonalAccount { get; set; }
        public int PersonalAccountId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
