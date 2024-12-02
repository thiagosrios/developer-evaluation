using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Represent a model that returns informations about the sale, like branch, products and totals
    /// that are not retrieved by the single get on the repository
    /// </summary>
    public class SaleData
    {
        /// <summary>
        /// Gets the number of the sale (it's not the base ID inherited from BaseEntity)
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets the id of the branch where the sale are created
        /// </summary>
        public Branch? Branch { get; set; } = new Branch();

        /// <summary>
        /// Gets the id from the customer who created the sale.
        /// </summary>
        public Customer? Customer { get; set; } = new Customer();

        /// <summary>
        /// Gets the list of the items on the sales 
        /// </summary>
        public List<SaleDataItem> Items { get; set; } = new();

        /// <summary>
        /// Gets status of the sale
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The total value of the sale (sum of its products).
        /// </summary>
        public decimal TotalAmount { get; set; } = 0;
    }

    public class SaleDataItem
    {
        /// <summary>
        /// Product of the sale item
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Quantity of the product ordered
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Original item price applied when the sale was created
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Discount calculated
        /// </summary>
        public decimal Discount { get; set; } = 0;

        public SaleDataItem(SaleItem item, Product? product)
        {
            Product = product;
            Quantity = item.Quantity;
            Price = item.Price;
            Discount = item.Discount.GetValueOrDefault();
        }
    }
}
