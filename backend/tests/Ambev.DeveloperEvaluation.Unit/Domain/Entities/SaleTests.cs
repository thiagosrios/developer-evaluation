using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        /// <summary>
        /// Tests that when a sales is canceled by the Customer
        /// </summary>
        [Fact(DisplayName = "Sales status should change to Approved to Canceled")]
        public void Given_CanceledSale_When_Canceled_Then_StatusShouldBeCanceled()
        {
            var sale = SaleTestData.GenerateSale();

            sale.Cancel();

            Assert.Equal(SaleStatus.Canceled, sale.Status);
            Assert.NotEqual(DateTime.MinValue, sale.UpdatedAt);
            Assert.NotEqual(sale.CreatedAt, sale.UpdatedAt);
        }

        /// <summary>
        /// Tests the generation of the Sale Number
        /// </summary>
        [Fact(DisplayName = "Sale should generate the Number when provided a current sale number")]
        public void Given_Sale_WhenGenerateNumber_Then_TheNumberHasToBeDifferentOfTheCurrent()
        {
            var sale = SaleTestData.GenerateSale();

            sale.GenerateSaleNumber(1);

            Assert.Equal(SaleStatus.Pending, sale.Status);
            Assert.NotEqual(DateTime.MinValue, sale.UpdatedAt);
            Assert.NotEqual(DateTime.MinValue, sale.CreatedAt);
        }

        /// <summary>
        /// Tests the generation of the Sale Number
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid sale data")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            var sale = SaleTestData.GenerateSale();

            var result = sale.Validate();

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
