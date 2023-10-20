using AutoMapper;
using Data;

namespace Domain
{
    /// <summary>
    /// ServiceMedication class which implements IServiceMedication interface.
    /// </summary>
    /// <seealso cref="IServiceMedication" />
    public class ServiceMedication : IServiceMedication
    {
        #region Attributes

        private readonly IRepository<Medication> _repository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMedication" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ServiceMedication(IRepository<Medication> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public async Task<Medication> CreateAsync(MedicationDTO medicationDTO)
        {
            Medication medication = _mapper.Map<MedicationDTO, Medication>(medicationDTO);
            medication.CreatedOn = DateTime.Now;
            medication.UpdatedOn = DateTime.Now;

            return await _repository.CreateAsync(medication);
        }

        /// <inheritdoc />
        public async Task<int> UpdateAsync(int id, MedicationDTO medicationDTO)
        {
            Medication medication = await _repository.GetByIdAsync(id);

            if (medication == null)
                return 0;

            medication = _mapper.Map(medicationDTO, medication);
            medication.UpdatedOn = DateTime.Now;

            return await _repository.UpdateAsync(medication);
        }

        /// <inheritdoc />
        public async Task<int> DeleteAsync(int id)
        {
            Medication medication = await _repository.GetByIdAsync(id);

            if (medication == null)
                return 0;
            
            return await _repository.DeleteAsync(medication);
        }

        #endregion
    }
}
