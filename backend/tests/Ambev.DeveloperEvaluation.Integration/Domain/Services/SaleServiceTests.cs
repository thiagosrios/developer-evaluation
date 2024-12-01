using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Integration.Domain.Services.TestData;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Domain.Services
{
    public class SaleServiceTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly SaleService _saleService;

        public SaleServiceTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _saleService = new SaleService(_saleRepository, _productRepository);
        }

        /// <summary>
        /// Tests the creation of a valid sale.
        /// </summary>
        [Fact(DisplayName = "Given valid sale should return the sale created")]
        public async Task Given_ValidSale_Then_ShouldReturnSale()
        {
            // Given
            var sale = SaleServiceTestData.GenerateSale();
            _saleRepository.GetLastSaleNumber().Returns(1);
            _saleRepository.CreateAsync(Arg.Any<Sale>()).Returns(sale);
            _productRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(SaleServiceTestData.GenerateProduct());

            // When
            var result = await _saleService.CreateSale(sale, CancellationToken.None);

            // Then
            Assert.NotNull(result);
            Assert.Equal(SaleStatus.Approved, result.Status);
            Assert.NotEqual(0, result.GetTotalSaleAmount());
        }

        /// <summary>
        /// Tests the creation of a sale with invalid data
        /// </summary>
        [Fact(DisplayName = "Given invalid sale should return errors")]
        public async Task Given_InvalidSale_Then_ShouldThrowErrors()
        {
            // Given
            var sale = SaleServiceTestData.GenerateInvalidSale();
            _saleRepository.GetLastSaleNumber().Returns(1);

            // When
            var act = () => _saleService.CreateSale(sale, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<ValidationException>(act);
        }
    }
}
