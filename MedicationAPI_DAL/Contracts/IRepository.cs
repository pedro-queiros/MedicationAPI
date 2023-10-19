
namespace MedicationAPI_DAL.Contracts
{
    /// <summary>
    /// IRepository interface which describe the basic CRUD operations of a repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        #region Methods

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>
        /// The enumerable of T.
        /// </returns>
        public Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The T with the corresponding identifier.
        /// </returns>
        public Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Creates the T asynchronous.
        /// </summary>
        /// <param name="_object">The T object.</param>
        /// <returns>
        /// The T created.
        /// </returns>
        public Task<T> CreateAsync(T _object);

        /// <summary>
        /// Updates the T asynchronous.
        /// </summary>
        /// <param name="_object">The T object.</param>
        /// <returns>
        /// The T updated.
        /// </returns>
        public Task<T> UpdateAsync(T _object);

        /// <summary>
        /// Deletes the T asynchronous.
        /// </summary>
        /// <param name="_object">The T object.</param>
        /// <returns>
        /// Returns 1 if successfully deleted, otherwise returns 0.
        /// </returns>
        public Task<int> DeleteAsync(T _object);

        #endregion
    }
}
