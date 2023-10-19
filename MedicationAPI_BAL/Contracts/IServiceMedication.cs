using MedicationAPI_DAL.Models;

namespace MedicationAPI_BAL.Contracts
{
    /// <summary>
    /// IServiceMedication Interface with CRUD methods.
    /// </summary>
    public interface IServiceMedication
    {
        #region Methods

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>
        /// Enumerable of Medication.
        /// </returns>
        Task<IEnumerable<Medication>> GetAllAsync();

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Medication with the respective id.
        /// </returns>
        Task<Medication> GetByIdAsync(int id);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// Medication created.
        /// </returns>
        Task<Medication> CreateAsync(Medication medication);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="medication">The medication.</param>
        /// <returns></returns>
        Task UpdateAsync(int id, Medication medication);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        #endregion
    }
}
