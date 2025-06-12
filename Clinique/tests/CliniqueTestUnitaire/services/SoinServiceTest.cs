using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentAssertions;
using Moq;
 
namespace CliniqueTestUnitaire.services
{
    public class SoinServiceTest
    {
        private readonly Mock<ISoinRepository> _repositoryMock;
        private readonly ISoinService _soinService;

        public SoinServiceTest()
        {
            _repositoryMock = new Mock<ISoinRepository>();
            _soinService = new SoinService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllSoin_ShouldBe_Return_Empty_When_Db_IS_Empty()
        {
            // Arrange
                _repositoryMock.Setup(s=>s.GetAllSoinAsync())
                .ReturnsAsync( new List<Soin>());
            // Action
            var result = await _soinService.GetAllSoinAsync();
            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllSoin_ShouldBe_Return_AllSoin_When_Db_IS_Empty()
        {
            // Arrange
            _repositoryMock.Setup(s => s.GetAllSoinAsync())
            .ReturnsAsync(new List<Soin> { new Soin { Id=1, TypeSoin="Soin1",Durees=1,prix=50}, new Soin { Id = 1, TypeSoin = "Soin2", Durees = 2, prix = 100 }});
            // Action
            var result = await _soinService.GetAllSoinAsync();
            // Assert
            result.Should().NotBeEmpty();
        }


    }
}
