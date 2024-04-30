using System;
using System.Collections.Generic;

namespace ManagementOfPersonalAccountData.Models
{
    public class PersonalAccount
    {
        public int Id { get; set; }
        public string NumberPA { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public double RoomArea { get; set; }
        public List<Resident> Residents { get; set; }

    }
}
