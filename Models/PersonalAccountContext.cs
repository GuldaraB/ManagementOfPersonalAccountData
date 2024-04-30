using Microsoft.EntityFrameworkCore;

namespace ManagementOfPersonalAccountData.Models
{
    public class PersonalAccountContext : DbContext
    {
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public PersonalAccountContext(DbContextOptions<PersonalAccountContext> options) : base(options) 
        {
        }
    }
}
