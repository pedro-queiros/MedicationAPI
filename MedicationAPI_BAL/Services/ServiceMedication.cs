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

        private readonly IRepository<Medication> _repository;

        #endregion

        #region Constructors

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

        /// <inheritdoc />
        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <inheritdoc />
        public async Task<Medication> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<Medication> CreateAsync(Medication medication)
        {
            return await _repository.CreateAsync(medication);
        }

        /// <inheritdoc />
        public async Task<Medication> UpdateAsync(int id, Medication medication)
        {
            Medication _medication = await _repository.GetByIdAsync(id);

            if (_medication != null)
            {
                MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Medication, Medication>());
                IMapper mapper = config.CreateMapper();
                _medication = mapper.Map(medication, _medication);
                return await _repository.UpdateAsync(_medication);
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<int> DeleteAsync(int id)
        {
            Medication medication = await _repository.GetByIdAsync(id);

            if (medication != null) 
                return await _repository.DeleteAsync(medication);

            return 0;
        }

        #endregion
    }
}
