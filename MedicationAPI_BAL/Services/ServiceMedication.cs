using AutoMapper;
using MedicationAPI_BAL.Contracts;
using MedicationAPI_DAL.Contracts;
using MedicationAPI_DAL.Models;

namespace MedicationAPI_BAL.Services
{
    public class ServiceMedication : IServiceMedication
    {
        public readonly IRepository<Medication> _repository;

        public ServiceMedication(IRepository<Medication> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {

            return await _repository.GetAllAsync();

        }

        public async Task<Medication> GetByIdAsync(int id)
        {

            return await _repository.GetByIdAsync(id);

        }

        public async Task<Medication> CreateAsync(Medication medication)
        {

            return await _repository.CreateAsync(medication);

        }

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

        public async Task DeleteAsync(int id)
        {

            if (id != 0)
            {
                var medication = await _repository.GetByIdAsync(id);
                if (medication != null) 
                    await _repository.DeleteAsync(medication);
            }

        }
    }
}
