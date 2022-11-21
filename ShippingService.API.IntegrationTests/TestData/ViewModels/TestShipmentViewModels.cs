﻿using ShippingService.API.ViewModels;
using ShippingService.API.ViewModels.Enums;

namespace ShippingService.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestShipmentViewModels
    {
        internal static ShipmentViewModel ShipmentViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<ShipmentViewModel> ShipmentViewModelCollection => new()
        {
            new ()
            {
                OrderId = 1,
                ShipmentStatus = ShipmentStatus.Preliminary,
                ShippingAddress = "ShippingAddress1",
            },
            new ()
            {
                OrderId = 1,
                ShipmentStatus = ShipmentStatus.Preliminary,
                ShippingAddress = "ShippingAdderess2",
            },
            new ()
            {
                OrderId = 1, 
                ShipmentStatus = ShipmentStatus.Preliminary, 
                ShippingAddress = "ShippingAddress3",
            },
        };

        internal static ChangeShipmentViewModel ChangeShipmentViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };
    }
}
