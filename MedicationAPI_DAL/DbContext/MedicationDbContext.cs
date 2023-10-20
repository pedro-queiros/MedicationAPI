using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    /// MedicationDbContext class representing a session with a medication database.
    /// </summary>
    /// <seealso cref="DbContext" />
    public class MedicationDbContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MedicationDbContext(DbContextOptions<MedicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationDbContext"/> class.
        /// </summary>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information and examples.
        /// </remarks>
        public MedicationDbContext()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the medications.
        /// </summary>
        /// <value>
        /// The DbSet of medications.
        /// </value>
        public virtual DbSet<Medication> Medications { get; set; }

        #endregion
    }
}
