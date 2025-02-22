using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.SharedKernel.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Commands;

public sealed class SetSalesOrderDeliveryDateConsumer(IRepository repository,
    IRabbitMQConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<SetSalesOrderDeliveryDate>(repository, connectionFactory, loggerFactory)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    protected override ICommandHandlerAsync<SetSalesOrderDeliveryDate> HandlerAsync =>
        new SetSalesOrderDeliveryDateCommandHandler(Repository, _loggerFactory);
}