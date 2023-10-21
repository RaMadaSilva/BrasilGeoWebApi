using BrasilGeo.Aplications.Adapter;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Handlers.UserHandler;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Commands.UserCommands;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Repositories;
using Moq;

namespace BrasilGeo.Test.HandlersTest
{
    public class UserHandlerTest
    {
        private readonly Mock<IUniteOfWork> _uow; 
        private readonly CreateUserHandler _handler;
        private readonly IAdapter<User, UserDto> _adapter;


        public UserHandlerTest()
        {
            _adapter = new UserToDtoAdapter();
            _uow = new Mock<IUniteOfWork>();
            _handler = new CreateUserHandler(_uow.Object, _adapter);

        }

        [Fact]
        public async Task HandleAsync_ShouldReturnSuccess_WhenUserIsSaved()
        {
            // Arrange
            var command = new CreateUserCommand { Email = "raul.silva@gmail.com", 
                        Password = "1234567890", 
                        Roles = {"Admin", "Reader" }
            };// Assuming is valid
            _uow.Setup(u => u.UserRepository.GetUserByEmailAsync(It.IsAny<string>()))
                           .ReturnsAsync((User)null);

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Usuario Salvo com Sucesso", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Email = "raul.silva",
                Password = "1234567890",
                Roles = { "Admin", "Reader" }
            }; // Assuming this makes it invalid

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Não foi possivel Criar o usuario", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenUserExists()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Email = "raul.silva@gmail.com",
                Password = "1234567890",
                Roles = { "Admin", "Reader" }
            }; // Assuming ES is valid
            _uow.Setup(u => u.UserRepository.GetUserByEmailAsync(It.IsAny<string>()))
                           .ReturnsAsync(new User("raul.silva@gmail.com",  "RaulTestePasss123"));

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Ja existe um usuario com esse email", result.Message);
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Email = "raul.silva@gmail.com",
                Password = "1234567890",
                Roles = { "Admin", "Reader" }
            }; // Assuming TS is valid
            _uow.Setup(u => u.UserRepository.GetUserByEmailAsync(It.IsAny<string>()))
                           .Throws(new Exception("Test Exception"));

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.StartsWith("Ocorreu um erro inesperado:", result.Message);
        }
    }
}
