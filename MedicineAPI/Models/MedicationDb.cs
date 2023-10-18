using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Models
{
    public class MedicationDb : IMedicationDb
    {
        public MedicationDb(DbContextOptions options) : base(options)
        {

        }


        public override DbSet<Medication> Medications { get; set; }

    }
}
