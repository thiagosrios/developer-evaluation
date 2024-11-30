namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleItemRequest
    {
        /// <summary>
        /// Id of the product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product ordered
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
