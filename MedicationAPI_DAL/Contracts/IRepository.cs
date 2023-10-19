
namespace MedicationAPI_DAL.Contracts
{
    /// <summary>
    /// IRepository interface to define the basic CRUD operations of a repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        #region Methods

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>
        /// Enumerable of T.
        /// </returns>
        public Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// T with the respective id.
        /// </returns>
        public Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Creates the T asynchronous.
        /// </summary>
        /// <param name="_object">The object.</param>
        /// <returns>
        /// T created.
        /// </returns>
        public Task<T> CreateAsync(T _object);
        /// <summary>
        /// Updates the T asynchronous.
        /// </summary>
        /// <param name="_object">The object.</param>
        /// <returns>/// </returns>
        public Task UpdateAsync(T _object);
        /// <summary>
        /// Deletes the T asynchronous.
        /// </summary>
        /// <param name="_object">The object.</param>
        /// <returns></returns>
        public Task DeleteAsync(T _object);

        #endregion
    }
}
