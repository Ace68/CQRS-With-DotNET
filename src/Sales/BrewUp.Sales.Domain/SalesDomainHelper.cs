using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.SharedKernel.Commands;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Domain;

public static class SalesDomainHelper
{
    public static IServiceCollection AddSalesDomain(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandlerAsync<SetSalesOrderDeliveryDate>, SetSalesOrderDeliveryDateCommandHandler>();

        return services;
    }
}