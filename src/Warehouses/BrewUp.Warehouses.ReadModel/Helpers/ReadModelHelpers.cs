using BrewUp.Shared.Contracts;
using BrewUp.Warehouses.ReadModel.Dtos;

namespace BrewUp.Warehouses.ReadModel.Helpers;

public static class ReadModelHelpers
{
	public static IEnumerable<SalesOrderRow> ToReadModelEntities(this IEnumerable<SalesOrderRowDto> dtos)
	{
		return dtos.Select(dto =>
			new SalesOrderRow
			{
				BeerId = dto.BeerId.ToString(),
				BeerName = dto.BeerName,
				Quantity = dto.Quantity,
				Price = dto.Price
			});
	}
}