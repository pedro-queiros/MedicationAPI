using MedicationAPI_DAL.Models;

namespace MedicationAPI_BAL.Contracts
{
    public interface IServiceMedication
    {
        Task<IEnumerable<Medication>> GetAllAsync();

        Task<Medication> GetByIdAsync(int id);

        Task<Medication> CreateAsync(Medication medication);

        Task UpdateAsync(int id, Medication medication);

        Task DeleteAsync(int id);
    }
}
