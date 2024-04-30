using ManagementOfPersonalAccountData.Models;

namespace ManagementOfPersonalAccountData.Services
{
    public interface IValidationService
    {
        bool IsValid(PersonalAccount account);
    }
}
