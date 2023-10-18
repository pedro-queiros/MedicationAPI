using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Models
{
    public abstract class IMedicationDb : DbContext
    {
        public IMedicationDb()
        {

        }

        public IMedicationDb(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Medication> Medications { get; set; }
    }
}
