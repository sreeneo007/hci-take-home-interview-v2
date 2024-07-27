using Moq;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Interfaces;
using PatientAdministrationSystem.Application.Repositories.Interfaces;
using PatientAdministrationSystem.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace PatientAdministrationSystem.Tests
{
    public class PatientsServiceTests
    {
        private readonly Mock<IPatientsRepository> _repositoryMock;
        private readonly PatientsService _patientsService;

        public PatientsServiceTests()
        {
            _repositoryMock = new Mock<IPatientsRepository>();
            _patientsService = new PatientsService(_repositoryMock.Object);
        }

        [Fact]
        public async Task SearchPatientsAsync_ShouldReturnMatchingPatients_WhenQueryIsValid()
        {
            // Arrange
            var query = "John";
            var expectedPatients = new List<PatientEntity>
            {
                new PatientEntity { FirstName = "John", LastName = "Sweeney", Email = "john.doe@hci.care.com" },
                new PatientEntity { FirstName = "Test", LastName = "exaple", Email = "Test.exaple@example.com" }
            };

            _repositoryMock.Setup(repo => repo.SearchPatientsAsync(query))
                .ReturnsAsync(expectedPatients);

            // Act
            var result = await _patientsService.SearchPatientsAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPatients.Count, result.Count());
            Assert.Contains(result, p => p.FirstName == "John" && p.LastName == "Sweeney");
        }

        [Fact]
        public async Task SearchPatientsAsync_ShouldReturnEmpty_WhenNoMatchingPatients()
        {
            // Arrange
            var query = "NonExistent";
            var expectedPatients = new List<PatientEntity>();

            _repositoryMock.Setup(repo => repo.SearchPatientsAsync(query))
                .ReturnsAsync(expectedPatients);

            // Act
            var result = await _patientsService.SearchPatientsAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
              
        [Fact]
        public async Task SearchPatientsAsync_ShouldReturnEmpty_WhenQueryIsEmpty()
        {
            // Arrange
            var query = "";

            // Act
            var result = await _patientsService.SearchPatientsAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

    }
}
