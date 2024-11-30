namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Represent a item of the sale with product and quantity
    /// </summary>
    public class CreateSaleItemCommand
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
