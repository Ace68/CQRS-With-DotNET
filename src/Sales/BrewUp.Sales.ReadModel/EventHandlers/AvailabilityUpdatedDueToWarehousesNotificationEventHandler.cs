﻿using BrewUp.Sales.ReadModel.Services;
using BrewUp.Sales.SharedKernel.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class AvailabilityUpdatedDueToWarehousesNotificationEventHandler(ILoggerFactory loggerFactory, IAvailabilityService availabilityService) : DomainEventHandlerAsync<AvailabilityUpdatedDueToWarehousesNotification>(loggerFactory)
{
	public override async Task HandleAsync(AvailabilityUpdatedDueToWarehousesNotification @event,
		CancellationToken cancellationToken = new())
	{
		cancellationToken.ThrowIfCancellationRequested();

		await availabilityService.UpdateAvailabilityAsync(@event.BeerId, @event.BeerName, @event.Quantity, cancellationToken);
	}
}