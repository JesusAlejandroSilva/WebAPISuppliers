using Entities;
using IRepositories;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using IServices;

namespace SupplierServicesTest
{
    public class SupplierServiceTest
    {
        private readonly Mock<ISuppliersRepository> _ISuppliersRepository;
        private readonly ISuppliersSevice _suppliersSevice;

        public SupplierServiceTest()
        {
            _ISuppliersRepository = new Mock<ISuppliersRepository>();
            _suppliersSevice = new SuppliersSevice(_ISuppliersRepository.Object);
        }

        [Fact]
        public async Task GetAllProveedoresAsync_ReturnsListOfProveedores()
        {
            // Arrange
            var proveedoresMock = new List<Suppliers> { new Suppliers { NIT = "123" } };
            _ISuppliersRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(proveedoresMock);

            // Act
            var result = await _suppliersSevice.GetAllProveedoresAsync();

            // Assert
            NUnit.Framework.Assert.NotNull(result);
        }
    }
}
