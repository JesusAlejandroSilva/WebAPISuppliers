using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Persistence;

namespace Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly DbContextApp _context;
    

        public SuppliersRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Suppliers>> GetAllAsync()
        {
            return await _context.Proveedores.Find(_ => true).ToListAsync();
        }

        public async Task<Suppliers> GetByIdAsync(int id)
        {
            return await _context.Proveedores.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Suppliers proveedor)
        {
            await _context.Proveedores.InsertOneAsync(proveedor);
        }

        public async Task UpdateAsync(Suppliers proveedor)
        {
            await _context.Proveedores.ReplaceOneAsync(p => p.Id == proveedor.Id, proveedor);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Proveedores.DeleteOneAsync(p => p.Id == id);
        }
    }
}

