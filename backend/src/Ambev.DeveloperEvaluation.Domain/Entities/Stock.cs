namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents the stock of the products on the Sales System
    /// Every registry holds the information of the products quantity on every branch
    /// </summary>
    public class Stock
    {
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Checks the quantity of the product available to sell
        /// </summary>
        /// <param name="requiredQuantity">Quantity required</param>
        /// <returns></returns>
        public bool CheckAvailabity(int requiredQuantity) 
        {
            if (AvailableQuantity == 0)
                return false;

            return AvailableQuantity >= requiredQuantity;
        }
    }
}
