using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueTestUnitaire.services
{
    public class PatientServiceTest
    {
        private Mock<IPatientRepository> _patientRepos;
        private IPatientService _patientService;
        public PatientServiceTest()
        {
            _patientRepos = new Mock<IPatientRepository>();
            _patientService = new PatientService(_patientRepos.Object);
        }
        [Fact]
        public async Task GetAllPatient_ShouldBe_Return_Empty_When_Db_IS_Empty()
        {
            // Arrange
            _patientRepos.Setup(m => m.GetAllPatientAsync())
              .ReturnsAsync(new List<Patient>());
            // Action
            var result = await _patientService.GetAllPatientAsync();
            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllPatient_ShouldBe_Return_AllPatient_When_Db_IS_NotEmpty()
        {
            // Arrange
            _patientRepos.Setup(m => m.GetAllPatientAsync())
              .ReturnsAsync(new List<Patient> {  new Patient { Id=1, Nom= "Patient1"}, new Patient { Id = 2, Nom = "Patient2" }});
            // Action
            var result = await _patientService.GetAllPatientAsync();
            // Assert
            result.Should().NotBeEmpty();
        }
    }
}
