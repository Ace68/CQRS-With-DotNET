using BrewUp.Warehouses.Acl;
using BrewUp.Warehouses.ReadModel.Services;
using BrewUp.Warehouses.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class SalesOrderCreatedConsumer(ISalesOrderService salesOrderService,
    IRabbitMQConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<SalesOrderCreatedForIntegration>(mufloneConnectionFactory, loggerFactory)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    protected override IEnumerable<IIntegrationEventHandlerAsync<SalesOrderCreatedForIntegration>> HandlersAsync =>
        new List<IIntegrationEventHandlerAsync<SalesOrderCreatedForIntegration>>
        {
            new SalesOrderCreatedForIntegrationEventHandler(_loggerFactory, salesOrderService)
        };
}