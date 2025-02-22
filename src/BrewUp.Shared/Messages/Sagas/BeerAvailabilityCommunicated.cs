﻿using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeerAvailabilityCommunicated(BeerId aggregateId, Guid correlationId, Availability availability)
	: IntegrationEvent(aggregateId, correlationId)
{
	public readonly BeerId BeerId = aggregateId;
	public readonly Availability Availability = availability;
}