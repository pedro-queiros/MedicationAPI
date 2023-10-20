using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    /// <summary>
    /// RepositoryMedication class which implements IRepository<Medication> interface.
    /// </summary>
    /// <seealso cref="Data.Contracts.IRepository&lt;Medication&gt;" />
    public class RepositoryMedication : IRepository<Medication>
    {
        #region Attributes

        private readonly MedicationDbContext _medicationDbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryMedication"/> class.
        /// </summary>
        /// <param name="medicationDbContext">The medication database context.</param>
        public RepositoryMedication(MedicationDbContext medicationDbContext)
        {
            _medicationDbContext = medicationDbContext;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            return await _medicationDbContext.Medications.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Medication> GetByIdAsync(int id)
        {
            return await _medicationDbContext.Medications.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<Medication> CreateAsync(Medication medication)
        {
            EntityEntry<Medication> result = _medicationDbContext.Add(medication);
            await _medicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        /// <inheritdoc />
        public async Task<Medication> UpdateAsync(Medication medication)
        {
            EntityEntry<Medication> result = _medicationDbContext.Update(medication);
            await _medicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        /// <inheritdoc />
        public async Task<int> DeleteAsync(Medication medication)
        {
            _medicationDbContext.Remove(medication);
            return await _medicationDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
