using BrewUp.Sales.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCreatedForIntegrationEventHandler(ILoggerFactory loggerFactory, IEventBus eventBus)
	: DomainEventHandlerAsync<SalesOrderCreated>(loggerFactory)
{
	public override async Task HandleAsync(SalesOrderCreated @event, CancellationToken cancellationToken = new())
	{
		try
		{
			await eventBus.PublishAsync(new SalesOrderCreatedForIntegration(@event.SalesOrderId, @event.MessageId, @event.SalesOrderNumber,
				@event.OrderDate, @event.CustomerId, @event.CustomerName, @event.Rows), cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error handling sales order created event");
			throw;
		}
	}
}