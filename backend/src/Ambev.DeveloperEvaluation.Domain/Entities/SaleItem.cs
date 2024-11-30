namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represent a item of the sale, with a product, the price calculated with discount and quantity 
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// The rereferenced id of the sale
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Id of the product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product ordered
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// The calculated price on the moment when the Sale was created. 
        /// If it has a discount, the price will be different of the product price 
        /// available on the moment of the sale
        /// </summary>
        public decimal Price { get; set; } = 0;
        
        /// <summary>
        /// Flag that indicates if the item has been canceled by the customer
        /// </summary>
        public bool Canceled { get; set; } = false;
        
        /// <summary>
        /// Virtual property that returns the TotalAMount of the SaleItem
        /// </summary>
        public decimal TotalAmount => Price * Quantity;
    }
}
