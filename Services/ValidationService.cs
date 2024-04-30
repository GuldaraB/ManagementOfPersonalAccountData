using ManagementOfPersonalAccountData.Models;
using System.Linq;

namespace ManagementOfPersonalAccountData.Services
{
    public class ValidationService : IValidationService
    {
        private readonly PersonalAccountContext _db;

        public ValidationService(PersonalAccountContext db)
        {
            _db = db;
        }

        public bool IsValid(PersonalAccount account)
        {
            var personalAccount = _db.PersonalAccounts.FirstOrDefault(c => c.NumberPA == account.NumberPA);

            if (account.StartDate < account.EndDate && personalAccount == null && account.RoomArea != null 
                && account.Address != null)
            {
                return true;
            }
            return false;
        }
    }
}
