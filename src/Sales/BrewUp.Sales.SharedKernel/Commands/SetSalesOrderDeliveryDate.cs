using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.CustomTypes;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.SharedKernel.Commands;

public sealed class SetSalesOrderDeliveryDate(SalesOrderId aggregateId, Guid commitId, DeliveryDate deliveryDate)
    : Command(aggregateId, commitId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly DeliveryDate DeliveryDate = deliveryDate;
}