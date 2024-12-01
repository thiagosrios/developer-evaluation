using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(
            ISaleRepository saleRepository, 
            IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public async Task<Sale> CreateSale(Sale sale, CancellationToken cancellationToken = default)
        {
            var lastSale = await _saleRepository.GetLastSaleNumber(cancellationToken);
            sale.GenerateSaleNumber(lastSale.GetValueOrDefault());

            var validator = new SaleValidator();
            var validationResult = validator.Validate(sale);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            sale.Approve();

            await SetItemsPrices(sale, cancellationToken);

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

            return createdSale;
        }

        private async Task SetItemsPrices(Sale sale, CancellationToken cancellationToken)
        {
            foreach (var item in sale.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                item.Price = product is null ? 0 : product.UnitPrice;
            }
        }
    }
}
