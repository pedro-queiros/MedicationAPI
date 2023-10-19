using MedicationAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI_DAL.Data
{
    public class MedicationDbContext : DbContext
    {
        #region Constructores

        public MedicationDbContext(DbContextOptions<MedicationDbContext> options) : base(options)
        {

        }

        public MedicationDbContext()
        {
            
        }

        #endregion

        #region DbSet

        public virtual DbSet<Medication> Medications { get; set; }

        #endregion
    }
}
