using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Models
{
    public class MedicationDb : DbContext
    {
        public MedicationDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Medication> Medications { get; set; }

    }
}
