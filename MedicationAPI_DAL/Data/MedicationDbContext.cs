using MedicationAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI_DAL.Data
{
    public class MedicationDbContext : DbContext
    {
        public MedicationDbContext(DbContextOptions<MedicationDbContext> options) : base(options)
        {

        }

        public DbSet<Medication> Medications { get; set; }
    }
}
