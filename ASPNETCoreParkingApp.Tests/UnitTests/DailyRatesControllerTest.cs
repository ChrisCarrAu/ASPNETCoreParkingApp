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

    public class DailyRatesControllerTest
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfDailyRates()
        {
            // Arrange
            var repository = new Mock<IDailyRateRepository>();
            var testParkingRates = GetTestDailyRates();
            repository.Setup(repo => repo.GetAllDailyRates()).Returns(testParkingRates);
            var controller = new DailyRatesController(repository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<DailyRate>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        private List<DailyRate> GetTestDailyRates()
        {
            var rates = new List<DailyRate>()
            {
                GetDailyRate(1, 5.00m),
                GetDailyRate(2, 10.00m),
                GetDailyRate(3, 15.00m),
            };
            return rates;
        }

        private DailyRate GetDailyRate(int id, decimal charge)
        {
            return new DailyRate
            {
                ID = id,
                Charge = charge,
            };
        }
    }
}
