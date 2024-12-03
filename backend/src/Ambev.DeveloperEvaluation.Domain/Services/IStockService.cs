namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IStockService
    {
        Task<bool> CheckProductAvailabilty(Guid productId, int requiredQuantity, Guid branchId, CancellationToken cancellationToken = default);
    }
}
