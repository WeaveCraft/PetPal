using PetPal_Business.Helpers;
using System;
using Xunit;

namespace PetPal_Tests
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

        [Fact]
        public void GetAge_ReturnsCorrectAge()
        {
            // Arrange
            var dob = new DateTime(1990, 1, 1); 
            var expectedAge = DateTime.UtcNow.Year - dob.Year; 

            // Act
            var age = dob.GetAge();

            // Assert
            Assert.Equal(expectedAge, age);
        }

        [Fact]
        public void GetAge_DateOnly_ReturnsCorrectAge()
        {
            // Arrange
            var dob = new DateOnly(1990, 1, 1); 
            var expectedAge = DateTime.UtcNow.Year - dob.Year; 

            // Act
            var age = dob.GetAge();

            // Assert
            Assert.Equal(expectedAge, age);
        }
    }
}
