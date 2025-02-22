using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.ReadModel.Services;

public interface ISalesOrderService
{
	Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, CustomerId customerId,
		CustomerName customerName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows, CancellationToken cancellationToken);

	Task<PagedResult<SalesOrderJson>> GetSalesOrdersAsync(int page, int pageSize, CancellationToken cancellationToken);
	Task CompleteSalesOrderAsync(SalesOrderId eventSalesOrderId, CancellationToken cancellationToken);
	Task SetSalesOrderDeliveryDateAsync(SalesOrderId eventSalesOrderId, DeliveryDate eventDeliveryDate, CancellationToken cancellationToken);
}