using BrewUp.Sales.ReadModel.EventHandlers;
using BrewUp.Sales.ReadModel.Services;
using BrewUp.Sales.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class SalesOrderDeliveryDateSetConsumer(
    IRabbitMQConnectionFactory connectionFactory,
    ISalesOrderService salesOrderService,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<SalesOrderDeliveryDateSet>(connectionFactory, loggerFactory)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    protected override IEnumerable<IDomainEventHandlerAsync<SalesOrderDeliveryDateSet>> HandlersAsync => new List<DomainEventHandlerAsync<SalesOrderDeliveryDateSet>>
    {
        new SalesOrderDeliveryDateSetEventHandler(_loggerFactory, salesOrderService)
    };
}