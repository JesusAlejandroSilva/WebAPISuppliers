using Entities;

namespace IRepositories
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Suppliers>> GetAllAsync();
        Task<Suppliers> GetByIdAsync(int id);
        Task AddAsync(Suppliers proveedor);
        Task UpdateAsync(Suppliers proveedor);
        Task DeleteAsync(int id);
    }
}
