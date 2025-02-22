using Muflone.Core;

namespace BrewUp.Warehouses.SharedKernel.CustomTypes;

public sealed class SalesOrderId : DomainId
{
	public SalesOrderId(Guid value) : base(value.ToString())
	{
	}
}