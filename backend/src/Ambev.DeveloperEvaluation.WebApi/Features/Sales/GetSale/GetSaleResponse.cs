﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
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
}