using BrewUp.Sales.SharedKernel.CustomTypes;
using Muflone.Messages.Events;

namespace BrewUp.Sales.SharedKernel.Events;

public sealed class SalesOrderDomainException(SalesOrderId aggregateId, Guid commitId, Exception exception)
    : DomainEvent(aggregateId, commitId)
{
    public readonly Exception Exception = exception;
}