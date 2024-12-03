using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IStockRepository using Entity Framework Core
    /// </summary>
    public class StockRepository : IStockRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of StockRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public StockRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Checks the available products on a branch by branchId and productId 
        /// </summary>
        /// <param name="branchId">Identifier of the branch</param>
        /// <param name="productId">Identifier of the product</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Stock if exists, null otherwise</returns>
        public async Task<Stock?> GetByBranchAndProduct(Guid branchId, Guid productId, CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .FirstOrDefaultAsync(x => x.BranchId == branchId && x.ProductId == productId);
        }
    }
}
