using BrasilGeo.Aplications.Commands.LocationIBGECommands;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Repositories;
using BrasilGeo.Test.Builder.Location;
using Moq;

namespace BrasilGeo.Test.Handlers.LocationIBGEHandler
{
    public class DeleteLocationIBGEHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteLocationIBGEHandler _handler;

        public DeleteLocationIBGEHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteLocationIBGEHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task HandleAsync_ShouldDeleteLocationSuccessfully()
        {
            // Arrange
            var command = new DeleteLocationIBGECommand();
            command.Id = 1;
            var fakeLocation = new LocationIBGEBuilder().WithId(1).WithCity("Santana").WithState("AP").Build();
            
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetByIdAsync(command.Id))
                           .ReturnsAsync(fakeLocation);

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("localidade Removida com sucesso", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenCommandIsInvalid()
        {
            // Arrange
            DeleteLocationIBGECommand command = new();
            command.Id = -1;

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Não é possivel remover a localidade", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenLocationDoesNotExist()
        {
            // Arrange
            var command = new DeleteLocationIBGECommand { Id = 1 }; 
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetByIdAsync(command.Id))
                           .ReturnsAsync((LocationIBGE)null);

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"Não existe uma localidade com Id = {command.Id}", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new DeleteLocationIBGECommand { Id = 1 }; 
            _unitOfWorkMock.Setup(u => u.LocationIBGERepository.GetByIdAsync(command.Id))
                           .Throws(new Exception("Test Exception"));

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.StartsWith("Ocorreu um erro inesperado:", result.Message);
        }
    }
}
