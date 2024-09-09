using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.TrainerVM;
using Microsoft.EntityFrameworkCore;

namespace GymManagementAPI.Service.Implement
{
    public class TrainerService : ITrainerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TrainerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TrainerVM>> GetAllAsync()
        {
            var trainersQuery = _context.Trainers.AsQueryable();
            var trainers = await trainersQuery.ToListAsync();
            return _mapper.Map<List<TrainerVM>>(trainers);
        }

        public async Task<TrainerVM> GetByIdAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return null;
            }
            return _mapper.Map<TrainerVM>(trainer);
        }

        public async Task<bool> CreateAsync(CreateTrainerVM model)
        {
            var trainerEntity = new Trainer
            {
                Name = model.Name,
                Specialty = model.Specialty,
                ExperienceYears = model.ExperienceYears,
                Email = model.Email,
                Phone = model.Phone
            };

            _context.Trainers.Add(trainerEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateTrainerVM model)
        {
            var trainerEntity = await _context.Trainers.FindAsync(id);
            if (trainerEntity == null) return false;

            trainerEntity.Name = model.Name;
            trainerEntity.Specialty = model.Specialty;
            trainerEntity.ExperienceYears = model.ExperienceYears;
            trainerEntity.Email = model.Email;
            trainerEntity.Phone = model.Phone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trainerEntity = await _context.Trainers.FindAsync(id);
            if (trainerEntity == null) return false;

            _context.Trainers.Remove(trainerEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
