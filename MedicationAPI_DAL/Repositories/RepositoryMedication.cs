using MedicationAPI_DAL.Contracts;
using MedicationAPI_DAL.Data;
using MedicationAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI_DAL.Repositories
{
    /// <summary>
    /// RepositoryMedication class responsible for interacting with the DbContext.
    /// </summary>
    /// <seealso cref="MedicationAPI_DAL.Contracts.IRepository&lt;MedicationAPI_DAL.Models.Medication&gt;" />
    public class RepositoryMedication : IRepository<Medication>
    {
        #region Attributes

        /// <summary>
        /// The medication database context
        /// </summary>
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

        /// <summary>
        /// Gets all Medication asynchronous.
        /// </summary>
        /// <returns>
        /// Enumerable of Medication.
        /// </returns>
        public async Task<IEnumerable<Medication>> GetAllAsync()
        {

            return await _medicationDbContext.Medications.ToListAsync();

        }

        /// <summary>
        /// Gets the Medication by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Medication with the respective id.
        /// </returns>
        public async Task<Medication> GetByIdAsync(int id)
        {

            return await _medicationDbContext.Medications.FindAsync(id);

        }

        /// <summary>
        /// Creates Medication asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns></returns>
        public async Task<Medication> CreateAsync(Medication medication)
        {
            _medicationDbContext.Add(medication);
            await _medicationDbContext.SaveChangesAsync();
            return medication;
        }

        /// <summary>
        /// Updates the Medication asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        public async Task UpdateAsync(Medication medication)
        {
            _medicationDbContext.Update(medication);
            await _medicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the Medication asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        public async Task DeleteAsync(Medication medication)
        {
            _medicationDbContext.Remove(medication);
            await _medicationDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
