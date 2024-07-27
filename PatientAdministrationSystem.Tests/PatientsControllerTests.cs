using Hci.Ah.Home.Api.Gateway.Controllers.Patients;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAdministrationSystem.Tests
{
    public class PatientsControllerTests
    {
        private readonly Mock<IPatientsService> _serviceMock;
        private readonly PatientsController _patientsController;

        public PatientsControllerTests()
        {
            _serviceMock = new Mock<IPatientsService>();
            _patientsController = new PatientsController(_serviceMock.Object);
        }
        
        [Fact]
        public async Task SearchPatients_ShouldReturnOk_WithMatchingPatients()
        {
            // Arrange
            var query = "John";
            var expectedPatients = new List<PatientEntity>
            {
                new PatientEntity { FirstName = "John", LastName = "Sweeney", Email = "john.Sweeney@hci.care.com" }
            };

            _serviceMock.Setup(service => service.SearchPatientsAsync(query))
                .ReturnsAsync(expectedPatients);

            // Act
            var result = await _patientsController.SearchPatients(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PatientEntity>>(okResult.Value);
            Assert.Equal(expectedPatients.Count, returnValue.Count());
        }

        [Fact]
        public async Task SearchPatients_ShouldReturnBadRequest_WhenQueryIsEmpty()
        {
            // Arrange
            var query = "";

            // Act
            var result = await _patientsController.SearchPatients(query);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task GetAllPatients_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange

            _serviceMock.Setup(service => service.GetAllPatientsAsync())
                .ThrowsAsync(new System.Exception("Test exception"));

            // Act
            var result = await _patientsController.GetAllPatients();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetAllPatients_ShouldReturnOk_WithAllPatients()
        {
            // Arrange
            var expectedPatients = new List<PatientEntity>
            {
                new PatientEntity { FirstName = "John", LastName = "Sweeney", Email = "john.Sweeney@hci.care.com" },
                new PatientEntity { FirstName = "Vinny", LastName = "lawlor", Email = "vinny.lawlor@hci.care.com" }
            };

            _serviceMock.Setup(service => service.GetAllPatientsAsync())
                .ReturnsAsync(expectedPatients);

            // Act
            var result = await _patientsController.GetAllPatients();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PatientEntity>>(okResult.Value);
            Assert.Equal(expectedPatients.Count, returnValue.Count());
        }
    }        
}
