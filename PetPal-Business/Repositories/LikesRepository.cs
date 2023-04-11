using Microsoft.EntityFrameworkCore;
using PetPal_Business.Helpers;
using PetPal_Business.Repositories.Interfaces;
using PetPal_DataAccess.Data;
using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Business.Repositories
{
    public class LikesRepository : ILikesRepository
    {
        private readonly ApplicationDbContext _context;
        public LikesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserLike> GetUserLike(int sourceUserId, int targetUserId)
        {
            return await _context.Likes.FindAsync(sourceUserId, targetUserId); 
        }

        public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            var users = _context.AppUsers.OrderBy(u => u.Username).AsQueryable();
            var likes = _context.Likes.AsQueryable();

            if(predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == userId);
                users = likes.Select(like => like.TargetUser);
            }
            
            if(predicate == "likedBy")
            {
                likes = likes.Where(like => like.TargetUserId == userId);
                users = likes.Select(like => like.SourceUser);
            }

            return await users.Select(user => new LikeDto
            {
                Username = user.Username,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.GetAge(),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain).Url,
                City = user.City,
                Id = user.Id
            }).ToListAsync();  
        }

        public async Task<AppUser> GetUserWithLikes(int userId)
        {
            return await _context.AppUsers
                .Include(x => x.LikedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);  
        }
    }
}
