using BrewUp.Warehouses.ReadModel.Services;
using BrewUp.Warehouses.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.Acl;

public sealed class SalesOrderCreatedForIntegrationEventHandler(ILoggerFactory loggerFactory, ISalesOrderService salesOrderService)
    : IntegrationEventHandlerAsync<SalesOrderCreatedForIntegration>(loggerFactory)
{
    public override async Task HandleAsync(SalesOrderCreatedForIntegration @event, CancellationToken cancellationToken = new())
    {
        try
        {
            await salesOrderService.CreateSalesOrderAsync(@event.SalesOrderId, @event.SalesOrderNumber,
                @event.CustomerId, @event.CustomerName, @event.OrderDate, @event.Rows, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error handling sales order created event");
            throw;
        }
    }
}