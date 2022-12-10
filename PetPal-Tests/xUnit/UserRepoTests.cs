using PetPal_Business.Repositories;
using PetPal_Business.Repositories.Interfaces;
using PetPal_DataAccess.Data;
using PetPal_Model.Models;
using Xunit;

namespace PetPal_Tests
{
    public class UserRepoTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserRepoTests(ApplicationDbContext context, UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [Fact]
        public void Getting_Users()
        {
            var user = _userRepository.GetUserByUsernameAsync("Helga".ToLower()); 

            var testUser = "Helga".ToLower();



        }
    }
}