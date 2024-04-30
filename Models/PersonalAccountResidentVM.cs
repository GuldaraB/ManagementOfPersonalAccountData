namespace ManagementOfPersonalAccountData.Models
{
    public class PersonalAccountResidentVM
    {
        public PersonalAccount PersonalAccount { get; set; }
        public int PersonalAccountId {  get; set; }
        public Resident Resident { get; set; }
        public int ResidentId { get; set; }
    }
}
