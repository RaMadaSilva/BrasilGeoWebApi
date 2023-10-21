using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Test.DomainTest.ValueObjectTest
{
    public class StateTest
    {
        [Fact]
        public void ValueObject_ShouldReturnSucess_WhenStateIsValid()
        {
            //Arrage
            var ufValid = "UE";

            //Act
            var state = new State(ufValid);

            //Assert
            Assert.Equal("UE", state.Uf); 
        }

        [Fact]
        public void ValueObject_ShouldReturnError_WhenStateIsNULLOrEmpty()
        {
            //arrage
            string ufInvalid = null;

            //Act and Assert
            Assert.Throws<Exception>(()=> new State(ufInvalid));  
        }
        [Theory]
        [InlineData("A")]
        [InlineData("TSC")]
        public void ValueObject_shouldRetornError_whenStateLengthInvalid(string invalidUf)
        {
            //Act and Assert
            Assert.Throws<Exception>(() => new State(invalidUf)); 
        }
    }
}
