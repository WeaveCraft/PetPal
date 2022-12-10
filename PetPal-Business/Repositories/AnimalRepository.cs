using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PetPal_Business.Repositories.Interfaces;
using PetPal_DataAccess.Data;
using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Business.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnimalRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Animal> GetAnimalByIdAsync(int id)
        {
            return await _context.Animals.FindAsync(id);
        }

        public async Task<Animal> GetAnimalByNameAsync(string name)
        {
            return await _context.Animals
                .Include(x => x.Photos)
                .SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<AnimalDto> GetPetsAsync(string name)
        {
            return await _context.Animals
                .Where(x => x.Name == name)
                .ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsAsync()
        {
            return await _context.Animals
                .Include(x => x.Photos)
                .ToListAsync();
        }

        public async Task<IEnumerable<AnimalDto>> GetPetsAsync()
        {
            return await _context.Animals
                .ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
        }

    }
}
