using Data;

namespace Domain
{
    /// <summary>
    /// IServiceMedication interface which describe the methods to manage medications.
    /// </summary>
    public interface IServiceMedication
    {
        #region Methods

        /// <summary>
        /// Gets all medications asynchronously.
        /// </summary>
        /// <returns>
        /// The enumerable of medications.
        /// </returns>
        Task<IEnumerable<Medication>> GetAllAsync();

        /// <summary>
        /// Gets the medication by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The medication with the corresponding identifier.
        /// </returns>
        Task<Medication> GetByIdAsync(int id);

        /// <summary>
        /// Creates the medication asynchronously.
        /// </summary>
        /// <param name="medication">The medication DTO.</param>
        /// <returns>
        /// The medication created.
        /// </returns>
        Task<Medication> CreateAsync(MedicationDTO medicationDTO);

        /// <summary>
        /// Updates the medication asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="medication">The medication DTO.</param>
        /// <returns>
        /// Returns 1 if successfully updated, otherwise returns 0.
        /// </returns>
        Task<int> UpdateAsync(int id, MedicationDTO medicationDTO);

        /// <summary>
        /// Deletes the medication asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns 1 if successfully deleted, otherwise returns 0.
        /// </returns>
        Task<int> DeleteAsync(int id);

        #endregion
    }
}
