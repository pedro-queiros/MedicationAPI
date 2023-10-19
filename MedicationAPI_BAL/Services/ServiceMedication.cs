using AutoMapper;
using MedicationAPI_BAL.Contracts;
using MedicationAPI_DAL.Contracts;
using MedicationAPI_DAL.Models;

namespace MedicationAPI_BAL.Services
{
    /// <summary>
    /// ServiceMedication class which implements IServiceMedication interface.
    /// </summary>
    /// <seealso cref="MedicationAPI_BAL.Contracts.IServiceMedication" />
    public class ServiceMedication : IServiceMedication
    {
        #region Attributes

        /// <summary>
        /// The repository
        /// </summary>
        public readonly IRepository<Medication> _repository;

        #endregion

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMedication"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ServiceMedication(IRepository<Medication> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>
        /// Enumerable of Medication.
        /// </returns>
        public async Task<IEnumerable<Medication>> GetAllAsync()
        {

            return await _repository.GetAllAsync();

        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Medication with the respective id.
        /// </returns>
        public async Task<Medication> GetByIdAsync(int id)
        {

            return await _repository.GetByIdAsync(id);

        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// Medication created.
        /// </returns>
        public async Task<Medication> CreateAsync(Medication medication)
        {

            return await _repository.CreateAsync(medication);

        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updatedMedication">The updated medication.</param>
        public async Task UpdateAsync(int id, Medication updatedMedication)
        {

            if (id != 0)
            {
                var medication = await _repository.GetByIdAsync(id);
                if (medication != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Medication, Medication>());
                    var mapper = config.CreateMapper();
                    medication = mapper.Map(updatedMedication, medication);
                    await _repository.UpdateAsync(medication);
                }
            }

        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteAsync(int id)
        {

            if (id != 0)
            {
                var medication = await _repository.GetByIdAsync(id);
                if (medication != null) 
                    await _repository.DeleteAsync(medication);
            }

        }

        #endregion
    }
}
