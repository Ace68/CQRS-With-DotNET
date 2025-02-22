using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.SharedKernel.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class SetSalesOrderDeliveryDateCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerAsync<SetSalesOrderDeliveryDate>(repository, loggerFactory)
{
    public override async Task HandleAsync(SetSalesOrderDeliveryDate command, CancellationToken cancellationToken = new CancellationToken())
    {
        var aggregate = await Repository.GetByIdAsync<SalesOrder>(command.SalesOrderId, cancellationToken);
        aggregate!.SetDeliveryDate(command.DeliveryDate, command.MessageId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}