﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Integration.Domain.Services.TestData;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Domain.Services
{
    public class SaleManagerServiceTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly SaleManagerService _saleService;

        public SaleManagerServiceTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _saleService = new SaleManagerService(_saleRepository, _productRepository);
        }

        /// <summary>
        /// Tests the creation of a valid sale.
        /// </summary>
        [Fact(DisplayName = "Given valid sale then should return the sale created")]
        public async Task Given_ValidSale_Then_ShouldReturnSale()
        {
            // Given
            var sale = SaleManagerServiceTestData.GenerateSale();
            _saleRepository.GetLastSaleNumber().Returns(1);
            _saleRepository.CreateAsync(Arg.Any<Sale>()).Returns(sale);
            _productRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(SaleManagerServiceTestData.GenerateProduct());

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
        [Fact(DisplayName = "Given invalid sale then should return errors")]
        public async Task Given_InvalidSale_Then_ShouldThrowErrors()
        {
            // Given
            var sale = SaleManagerServiceTestData.GenerateInvalidSale();
            _saleRepository.GetLastSaleNumber().Returns(1);

            // When
            var act = () => _saleService.CreateSale(sale, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<ValidationException>(act);
        }

        /// <summary>
        /// Tests the update of a existent sale.
        /// </summary>
        [Fact(DisplayName = "Given valid updated sale then should return the sale created")]
        public async Task Given_ValidUpdatedSale_Then_ShouldReturnSale()
        {
            // Given
            var sale = SaleManagerServiceTestData.GenerateSale();
            sale.Update(new List<SaleItem>(), false);
            _saleRepository.UpdateAsync(Arg.Any<Sale>()).Returns(sale);
            _productRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(SaleManagerServiceTestData.GenerateProduct());

            // When
            var result = await _saleService.UpdateSale(sale, CancellationToken.None);

            // Then
            Assert.NotNull(result);
            Assert.Equal(SaleStatus.Approved, result.Status);
            Assert.NotEqual(0, result.GetTotalSaleAmount());
        }
    }
}
