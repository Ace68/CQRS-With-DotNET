using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.ReadModel.Helpers;
using BrewUp.Warehouses.SharedKernel.CustomTypes;

namespace BrewUp.Warehouses.ReadModel.Dtos;

public class SalesOrder : EntityBase
{
	public string OrderNumber { get; private set; } = string.Empty;

	public string CustomerId { get; private set; } = string.Empty;
	public string CustomerName { get; private set; } = string.Empty;

	public DateTime OrderDate { get; private set; } = DateTime.MinValue;

	public IEnumerable<SalesOrderRow> Rows { get; private set; } = [];
	
	public DateTime DeliveryDate { get; private set; } = DateTime.MaxValue;

	public string Status { get; private set; } = string.Empty;

	protected SalesOrder()
	{ }

	public static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, CustomerId customerId,
		CustomerName customerName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows) => new(salesOrderId.Value.ToString(),
		salesOrderNumber.Value, customerId.Value.ToString(), customerName.Value, orderDate.Value, rows.ToReadModelEntities());

	private SalesOrder(string salesOrderId, string salesOrderNumber, string customerId, string customerName, DateTime orderDate, IEnumerable<SalesOrderRow> rows)
	{
		Id = salesOrderId;
		OrderNumber = salesOrderNumber;
		CustomerId = customerId;
		CustomerName = customerName;
		OrderDate = orderDate;
		Rows = rows;

		DeliveryDate = DateTime.MaxValue;
		Status = Shared.Helpers.Status.Created.Name;
	}
}