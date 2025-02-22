using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainIds;
using BrewUp.Warehouses.SharedKernel.CustomTypes;

namespace BrewUp.Warehouses.ReadModel.Services;

public interface ISalesOrderService
{
    Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, CustomerId customerId,
        CustomerName customerName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows, CancellationToken cancellationToken);
}