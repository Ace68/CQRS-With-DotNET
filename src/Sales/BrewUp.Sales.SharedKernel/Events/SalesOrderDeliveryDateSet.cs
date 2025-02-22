using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace BrewUp.Sales.SharedKernel.Events;

public sealed class SalesOrderDeliveryDateSet(SalesOrderId aggregateId, Guid commitId, DeliveryDate deliveryDate)
    : DomainEvent(aggregateId, commitId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly DeliveryDate DeliveryDate = deliveryDate;
}