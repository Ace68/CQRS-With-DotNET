using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.ReadModel.Dtos;
using BrewUp.Warehouses.SharedKernel.CustomTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public sealed class SalesOrderService(ILoggerFactory loggerFactory, [FromKeyedServices("warehouses")] IPersister persister )
	: ServiceBase(loggerFactory, persister), ISalesOrderService
{
	public async Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, CustomerId customerId,
		CustomerName customerName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows, CancellationToken cancellationToken)
	{
		try
		{
			var salesOrder = SalesOrder.CreateSalesOrder(salesOrderId, salesOrderNumber, customerId, customerName, orderDate, rows);
			await Persister.InsertAsync(salesOrder, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error creating sales order");
			throw;
		}
	}
}