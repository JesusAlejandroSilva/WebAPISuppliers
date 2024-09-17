using Entities;

namespace IServices
{
    public interface ISuppliersSevice
    {
        Task<IEnumerable<Suppliers>> GetAllProveedoresAsync();
        Task<Suppliers> GetProveedorByIdAsync(int id);
        Task AddProveedorAsync(Suppliers suppliers);
        Task UpdateProveedorAsync(Suppliers suppliers);
        Task DeleteProveedorAsync(int id);
    }
}
