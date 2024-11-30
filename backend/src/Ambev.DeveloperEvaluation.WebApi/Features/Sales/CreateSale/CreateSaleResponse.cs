using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        /// <summary>
        /// Gets the number of the sale (it's not the base ID inherited from BaseEntity)
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets the list of the items on the sales 
        /// </summary>
        public List<CreateSaleItemResponse> Items { get; set; } = new();

        /// <summary>
        /// Gets status of the sale
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }

    public class CreateSaleItemResponse
    {
        /// <summary>
        /// Id of the product
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity of the product ordered
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
