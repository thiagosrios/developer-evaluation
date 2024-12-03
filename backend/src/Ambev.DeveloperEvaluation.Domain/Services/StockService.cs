using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    /// <summary>
    /// Class to retrieve informations about the Stock of product on specific branchs
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        /// <summary>
        /// Checks the availabilty of a product on a specific branch
        /// </summary>
        /// <param name="productId">Product required</param>
        /// <param name="requiredQuantity">Quantity of the required product</param>
        /// <param name="branchId">Branch where the product is stocked</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> CheckProductAvailabilty(
            Guid productId, 
            int requiredQuantity, 
            Guid branchId, 
            CancellationToken cancellationToken = default)
        {
            var stockRegistry = await _stockRepository.GetByBranchAndProduct(branchId, productId, cancellationToken);
        
            if (stockRegistry == null)
                return false;

            return stockRegistry.CheckAvailabity(requiredQuantity);
        }
    }
}
