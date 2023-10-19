using MedicationAPI_DAL.Contracts;
using MedicationAPI_DAL.Data;
using MedicationAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI_DAL.Repositories
{
    public class RepositoryMedication : IRepository<Medication>
    {
        private readonly MedicationDbContext _medicationDbContext;

        public RepositoryMedication(MedicationDbContext medicationDbContext)
        {
            _medicationDbContext = medicationDbContext;
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {

            return await _medicationDbContext.Medications.ToListAsync();

        }

        public async Task<Medication> GetByIdAsync(int id)
        {

            return await _medicationDbContext.Medications.FindAsync(id);

        }

        public async Task<Medication> CreateAsync(Medication medication)
        {
            _medicationDbContext.Add(medication);
            await _medicationDbContext.SaveChangesAsync();
            return medication;
        }

        public async Task UpdateAsync(Medication medication)
        {
            _medicationDbContext.Update(medication);
            await _medicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medication medication)
        {
            _medicationDbContext.Remove(medication);
            await _medicationDbContext.SaveChangesAsync();
        }
    }
}
