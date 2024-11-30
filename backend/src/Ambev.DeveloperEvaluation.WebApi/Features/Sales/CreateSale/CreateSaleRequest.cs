﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets the id of the branch where the sale are created
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets the id from the customer who created the sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets the list of the items on the sale 
        /// </summary>
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }
}
