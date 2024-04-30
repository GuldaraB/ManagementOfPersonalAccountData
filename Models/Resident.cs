namespace ManagementOfPersonalAccountData.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fatherland { get; set; }
        public PersonalAccount PersonalAccount { get; set; }
        public int PersonalAccountId { get; set; }

    }
}
