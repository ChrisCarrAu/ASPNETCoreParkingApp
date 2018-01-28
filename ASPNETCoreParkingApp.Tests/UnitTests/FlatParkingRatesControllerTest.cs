using ASPNETCoreParkingApp.Controllers;
using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ASPNETCoreParkingApp.Tests.UnitTests
{

    public class FlatParkingRatesControllerTest
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfFlatParkingRates()
        {
            // Arrange
            var repository = new Mock<IFlatParkingRateRepository>();
            var testParkingRates = GetTestFlatParkingRates();
            repository.Setup(repo => repo.GetAllFlatParkingRates()).Returns(testParkingRates);
            var controller = new FlatParkingRatesController(repository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FlatParkingRate>>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        private List<FlatParkingRate> GetTestFlatParkingRates()
        {
            var rates = new List<FlatParkingRate>()
            {
                GetFlatParkingRate(1, "Early Bird", new TimeSpan(6, 0, 0), new TimeSpan(9, 0, 0),
                    new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0), 64, 13.00m)
            };
            return rates;
        }

        private FlatParkingRate GetFlatParkingRate(int id, string description, TimeSpan entryStart, TimeSpan entryEnd, TimeSpan exitStart, TimeSpan exitEnd, int entryDays, decimal charge)
        {
            return new FlatParkingRate
            {
                ID = id,
                Description = description,
                EntryTimeStart = entryStart,
                EntryTimeEnd = entryEnd,
                ExitTimeStart = exitStart,
                ExitTimeEnd = exitEnd,
                EntryDays = entryDays,
                Charge = charge,
            };
        }

        /*
        private static FlatParkingRatesController GetFlatParkingRatesController(IFlatParkingRateRepository repository)
        {
            FlatParkingRatesController controller = new MockFlatParkingRateRepository();

            return controller;
        }

        
        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                new GenericIdentity("someUser"), null roles );

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
        */
    }
}
