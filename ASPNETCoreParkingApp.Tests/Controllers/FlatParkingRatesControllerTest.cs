using ASPNETCoreParkingApp.Controllers;
using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using ASPNETCoreParkingApp.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ASPNETCoreParkingApp.Tests.Controllers
{

    public class FlatParkingRatesControllerTest
    {
        [Fact]
        public async Task Index_Get_AsksForIndexViewAsync()
        {
            var repository = new MockFlatParkingRateRepository();
            repository.Add(GetFlatParkingRate());

            // Arrange
            var controller = new FlatParkingRatesController(repository);

            // Act
            var actionResultTask = controller.Index();
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;


            // Assert
            Assert.NotNull(viewResult);
            Assert.Equal("Index", viewResult.ViewName);
        }


        FlatParkingRate GetFlatParkingRate()
        {
            return GetFlatParkingRate(1, "Early Bird", new TimeSpan(6, 0, 0), new TimeSpan(9, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(23, 30, 0), 64, 13.00m);
        }

        FlatParkingRate GetFlatParkingRate(int id, string description, TimeSpan entryStart, TimeSpan entryEnd, TimeSpan exitStart, TimeSpan exitEnd, int entryDays, decimal charge)
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
