﻿using ShippingService.BLL.Models;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.API.IntegrationTests.TestData.Entities
{
    internal static class TestShipmentModels
    {
        internal static Shipment Shipment => new()
        {
            Id = new Guid(1, 0, 0, new byte[8]),
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<Shipment> ShipmentCollection => new()
        {
            Shipment,
        };
    }
}
