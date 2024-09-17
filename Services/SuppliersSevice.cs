using Entities;
using IRepositories;
using IServices;

namespace Services
{
    public class SuppliersSevice: ISuppliersSevice
    {
        private readonly ISuppliersRepository _supplierRepository;

        public SuppliersSevice(ISuppliersRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Suppliers>> GetAllProveedoresAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<Suppliers> GetProveedorByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        public async Task AddProveedorAsync(Suppliers proveedor)
        {
            await _supplierRepository.AddAsync(proveedor);
        }

        public async Task UpdateProveedorAsync(Suppliers proveedor)
        {
            await _supplierRepository.UpdateAsync(proveedor);
        }

        public async Task DeleteProveedorAsync(int id)
        {
            await _supplierRepository.DeleteAsync(id);
        }
    }
}

