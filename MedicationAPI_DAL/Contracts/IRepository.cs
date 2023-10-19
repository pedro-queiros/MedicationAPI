
namespace MedicationAPI_DAL.Contracts
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> CreateAsync(T _object);
        public Task UpdateAsync(T _object);
        public Task DeleteAsync(T _object);
    }
}
