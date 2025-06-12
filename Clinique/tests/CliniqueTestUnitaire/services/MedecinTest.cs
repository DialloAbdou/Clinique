using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentAssertions;
using Moq;

namespace CliniqueTestUnitaire.services
{
    public class MedecinTest
    {
        private Mock<IMedecinRepository> _medecinRepositoryMock;
        private IMedecinService _medecinService;
        public MedecinTest()
        {
            _medecinRepositoryMock = new Mock<IMedecinRepository>();
            _medecinService = new MedecinService(_medecinRepositoryMock.Object);
        }
        /// <summary>
        /// liste db vide
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllMedecin_ShouldBe_Return_Empty_When_Db_IS_Empty()
        {
            // Arrange
            _medecinRepositoryMock.Setup(m => m.GetAllMedecinAsync())
              .ReturnsAsync(new List<Medecin>());
            // Action
            var result = await _medecinService.GetAllMedecinAsync();
            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// liste de db non vide
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllMedecin_ShouldBe_Return_AllMedecin_When_Db_IS_NotEmpty()
        {
            // Arrange
            _medecinRepositoryMock.Setup(m => m.GetAllMedecinAsync())
              .ReturnsAsync(new List<Medecin> { new Medecin { Id = 1, Nom = "Medecin1" } });
            // Action
            var result = await _medecinService.GetAllMedecinAsync();
            // Assert
            result.Should().NotBeEmpty();
        }
    }
}
