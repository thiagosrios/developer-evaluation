using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Integration.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        public static CreateSaleCommand CreateValidCommand()
        {
            return new CreateSaleCommand()
            {
                BranchId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                Items = new List<CreateSaleItemCommand>()
                {
                    new CreateSaleItemCommand() 
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 10
                    }
                }
            };
        }

        public static CreateSaleCommand CreateInvalidCommand()
        {
            return new CreateSaleCommand()
            {
                BranchId = Guid.Empty,
                CustomerId = Guid.Empty,
                Items = new List<CreateSaleItemCommand>()
            };
        }
    }
}
