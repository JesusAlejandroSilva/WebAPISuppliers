using Entities;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISuppliersSevice _suppliersSevice;

        /// <summary>
        /// Obtiene todos los proveedores registrados.
        /// </summary>
        /// <returns>Una lista de proveedores.</returns>
        public SuppliersController(ISuppliersSevice suppliersSevice)
        {
            _suppliersSevice = suppliersSevice;
        }

        /// <summary>
        /// Obtiene todos los proveedores registrados.
        /// </summary>
        /// <returns>Una lista de proveedores.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _suppliersSevice.GetAllProveedoresAsync();
            return Ok(proveedores);
        }

        /// <summary>
        /// Obtiene un proveedor por su NIT.
        /// </summary>
        /// <param name="nit">El NIT del proveedor.</param>
        /// <returns>El proveedor con el NIT especificado.</returns>
        [HttpGet("{nit}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int nit)
        {
            var proveedor = await _suppliersSevice.GetProveedorByIdAsync(nit);
            if (proveedor == null) return NotFound();
            return Ok(proveedor);
        }

        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="suppliers">Objeto de creación del proveedor.</param>
        /// <returns>El proveedor creado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Suppliers suppliers)
        {
            await _suppliersSevice.AddProveedorAsync(suppliers);
            return CreatedAtAction(nameof(GetById), new { id =  suppliers.Id }, suppliers);
        }

        /// <summary>
        /// Actualiza un proveedor existente.
        /// </summary>
        /// <param name="id">El NIT del proveedor a actualizar.</param>
        /// <param name="suppliers">Datos del proveedor a actualizar.</param>
        /// <returns>No Content si se actualiza correctamente.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] Suppliers suppliers)
        {
            suppliers.Id = id;
            await _suppliersSevice.UpdateProveedorAsync(suppliers);
            return NoContent();
        }

        /// <summary>
        /// Elimina un proveedor por su NIT.
        /// </summary>
        /// <param name="nit">El NIT del proveedor a eliminar.</param>
        /// <returns>No Content si se elimina correctamente.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _suppliersSevice.DeleteProveedorAsync(id);
            return NoContent();
        }

    }
}
