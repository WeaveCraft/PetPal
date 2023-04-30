using PetPal_Business.Helpers;
using System;
using Xunit;

namespace PetPal_Tests.xUnit
{
    public class CalculateUserAgeTests
    {
        [Fact]
        public void CalculateAge_ReturnsCorrectAge()
        {
            // Arrange
            var dob = new DateOnly(1990, 1, 1); 
            var expectedAge = DateTime.UtcNow.Year - dob.Year; 

            // Act
            var age = dob.CalculateAge();

            // Assert
            Assert.Equal(expectedAge, age);
        }
    }
}
