using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> GetByBranchAndProduct(Guid branchId, Guid productId, CancellationToken cancellationToken = default);
    }
}
