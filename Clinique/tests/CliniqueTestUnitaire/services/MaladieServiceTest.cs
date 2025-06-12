using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentAssertions;
using Moq;

namespace CliniqueTestUnitaire.services
{
    public class MaladieServiceTest
    {
        private Mock<IMaladeRepository> _repositoryMock;
        private readonly IMaladeService _service;
        public MaladieServiceTest()
        {
            _repositoryMock = new Mock<IMaladeRepository>();
            _service = new MaladeService(_repositoryMock.Object);
        }

        /// <summary>
        /// test list des malades db vides
        /// </summary>
        /// <returns></returns>
        [Fact]  
        public async Task GetAllMaladie_ShouldBe_Return_Empty_When_Db_IS_Empty()
        {
            // Arrange
            _repositoryMock.Setup(m => m.GetAllMaladiesAsync())
              .ReturnsAsync(new List<Maladie>());
            // Action
                 var result = await _service.GetAllMaladiesAsync();
            // Assert
             result.Should().BeEmpty();
        }


        /// <summary>
        /// test listes db non vide
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllMaladie_ShouldBe_Return_AllMaladies_When_Db_IS_NotEmpty()
        {
            // Arrange
            _repositoryMock.Setup(m => m.GetAllMaladiesAsync())
              .ReturnsAsync(new List<Maladie> {new Maladie { Id = 1, Pathologie = "scarlatine" }, new Maladie { Id = 2, Pathologie = "Varicelle"}});
            // Action
            var result = await _service.GetAllMaladiesAsync();
            // Assert
            result.Should().NotBeEmpty();
        }

    }
}
