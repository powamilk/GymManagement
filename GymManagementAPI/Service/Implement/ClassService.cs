using GymManagementAPI.ViewModel.ClassVM;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GymManagementAPI.Service.Implement
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClassVM>> GetAllAsync()
        {
            var classesQuery = _context.Classes.AsQueryable();
            var classes = await classesQuery.ToListAsync();
            return _mapper.Map<List<ClassVM>>(classes);
        }

        public async Task<ClassVM> GetByIdAsync(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
            {
                return null;
            }
            return _mapper.Map<ClassVM>(classEntity);
        }

        public async Task<bool> CreateAsync(CreateClassVM model)
        {
            var classEntity = new Class
            {
                Name = model.Name,
                TrainerId = model.TrainerId,
                Schedule = model.Schedule,
                MaxMembers = model.MaxMembers,
                CurrentMembers = 0
            };

            _context.Classes.Add(classEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateClassVM model)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null) return false;

            classEntity.Name = model.Name;
            classEntity.TrainerId = model.TrainerId;
            classEntity.Schedule = model.Schedule;
            classEntity.MaxMembers = model.MaxMembers;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null) return false;

            _context.Classes.Remove(classEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
