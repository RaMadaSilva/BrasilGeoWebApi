using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Test.DomainTest.ValueObjectTest
{
    public class EmailTest
    {
        [Fact]
        public void ValueObject_ShouldSucess_WhenUserValid()
        {
            //arrage
            var adressValid = "raul.silva@gmail.com"; 

            //Act
            var email = new Email(adressValid);

            //Assert
            Assert.Equal("raul.silva@gmail.com", email); 
        }
        [Fact]
        public void ValueObject_ShouldError_WhenEmailNullOrEmpty()
        {
            //Arrage
            string addressInv = string.Empty;

            //Act and assert
            Assert.Throws<Exception>(() => new Email(addressInv)); 

        }

        [Fact]
        public void ValueObject_ShouldError_WhenEmailLengthLessFive()
        {
            //Arrage
            var adressInv = "r@m"; 

            // and Assert
            Assert.Throws<Exception>(() => new Email(adressInv)); 
        }

        [Fact]
        public void ValueObject_ShouldError_WhenEmailRegexInvalid()
        {
            //Arrage
            var adressInvalid = "raul.silva";

            //Act and Assert
            try
            {
                var mail = new Email(adressInvalid);
                Assert.True(false, "Uma Excepção deve ser lançado"); 

            }catch(Exception ex)
            {
                Assert.Equal("E-mail Invalido #3", ex.Message); 
            }
        }

    }
}
