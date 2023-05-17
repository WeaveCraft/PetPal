using Moq;
using Xunit;
using PetPal_Business.Repositories.Interfaces;
using PetPal_Model.Models;
using System.Threading.Tasks;
using PetPal_DataAccess.Data;

namespace PetPal_Tests
{
    public class UserRepositoryTests
    {
        //Mock
        public Mock<IUserRepository> _userRepositoryMock { get; set; }
        public IUserRepository _sut { get; set; }
        public Mock<ApplicationDbContext> _context { get; set; }

        public UserRepositoryTests()
        {
            var user = (AppUser)null;

            var testUser = new AppUser
            {
                Id = 1,
                Username = "Helga",
                KnownAs = "Helga",
                Gender = "Female",
                Mood = "Playful",
            };

            _userRepositoryMock = new Mock<IUserRepository>();
            _userRepositoryMock.Setup(x => x.GetUserByIdAsync(100)).ReturnsAsync(user);
            _userRepositoryMock.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(testUser);

            _sut = _userRepositoryMock.Object;
        }

        [Fact]
        public void GetUserByUsernameAsync_HandleNull()
        {
            // Act
            var result = _sut.GetUserByIdAsync(-1);
            //var user = _context.AppUsers.Find(-1);

            // Assert
            Assert.Null(result.Result);

        }

        [Fact]
        public async Task GetUser_WithExistingId()
        {
            // Arrange
            var expectedUser = new AppUser
            {
                Id = 1,
                Username = "Helga",
                KnownAs = "Helga",
                Gender = "Female",
                Mood = "Playful",
            };

            // Act
            var result = await _sut.GetUserByIdAsync(1);

            // Assert
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.Username, result.Username);
            Assert.Equal(expectedUser.KnownAs, result.KnownAs);
            Assert.Equal(expectedUser.Gender, result.Gender);
            Assert.Equal(expectedUser.Mood, result.Mood);
        }


    }
}