using MedicationAPI_DAL.Models;

namespace MedicationAPI_BAL.Contracts
{
    /// <summary>
    /// IServiceMedication interface which describe the methods to manage medications.
    /// </summary>
    public interface IServiceMedication
    {
        #region Methods

        /// <summary>
        /// Gets all medications asynchronous.
        /// </summary>
        /// <returns>
        /// The enumerable of medications.
        /// </returns>
        Task<IEnumerable<Medication>> GetAllAsync();

        /// <summary>
        /// Gets the medication by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The medication with the corresponding identifier.
        /// </returns>
        Task<Medication> GetByIdAsync(int id);

        /// <summary>
        /// Creates the medication asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// The medication created.
        /// </returns>
        Task<Medication> CreateAsync(Medication medication);

        /// <summary>
        /// Updates the medication asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// The medication updated.
        /// </returns>
        Task<Medication> UpdateAsync(int id, Medication medication);

        /// <summary>
        /// Deletes the medication asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns 1 if successfully deleted, otherwise returns 0.
        /// </returns>
        Task<int> DeleteAsync(int id);

        #endregion
    }
}
