using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Repositories;
using Moq;

namespace BrasilGeo.Test.Handlers.LocationIBGEHandler
{
    public class CreateLocationIBGEHandlerTests
    {
        private readonly Mock<IUniteOfWork> _unitOfWorkMock;
        private readonly CreateLocationIBGEHandler _handler;

        public CreateLocationIBGEHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUniteOfWork>();
            _handler = new CreateLocationIBGEHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnSuccess_WhenLocationIsSaved()
        {
            // Arrange
            var command = new CreateLocationIBGECommand { City = "TestCity", State = "TS" }; // Assuming TS is valid
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetLocationIBGEByCityNameAndStateNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                           .ReturnsAsync((LocationIBGE)null);

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Localidade salva com sucesso!", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new CreateLocationIBGECommand { City = "TestCity", State = "TSA" }; 

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Não foi possivel salvar uma Localizacao", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenLocationExists()
        {
            // Arrange
            var command = new CreateLocationIBGECommand { State = "ES", City = "ExistingCity" }; 
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetLocationIBGEByCityNameAndStateNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                           .ReturnsAsync(new LocationIBGE("ES", "ExistingCity"));

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Ja existe uma localidade com esta cidade e estado", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateLocationIBGECommand { City = "TestCity", State = "TS" }; 
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetLocationIBGEByCityNameAndStateNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                           .Throws(new Exception("Test Exception"));

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.StartsWith("Ocorreu um erro inesperado:", result.Message);
        }
    }
}