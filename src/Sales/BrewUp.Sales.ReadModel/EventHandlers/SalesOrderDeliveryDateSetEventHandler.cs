using BrewUp.Sales.ReadModel.Services;
using BrewUp.Sales.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderDeliveryDateSetEventHandler(ILoggerFactory loggerFactory, ISalesOrderService salesOrderService)
    : DomainEventHandlerAsync<SalesOrderDeliveryDateSet>(loggerFactory)
{
    public override async Task HandleAsync(SalesOrderDeliveryDateSet @event, CancellationToken cancellationToken = new())
    {
        try
        {
            await salesOrderService.SetSalesOrderDeliveryDateAsync(@event.SalesOrderId, @event.DeliveryDate, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error handling sales order deliveryDate set event");
            throw;
        }
    }
}