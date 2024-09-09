using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassRegistrationVM;
using Microsoft.EntityFrameworkCore;

namespace GymManagementAPI.Service.Implement
{
    public class ClassRegistrationService : IClassRegistrationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassRegistrationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClassRegistrationVM>> GetAllAsync()
        {
            var registrationsQuery = _context.ClassRegistrations.AsQueryable();
            var registrations = await registrationsQuery.ToListAsync();
            return _mapper.Map<List<ClassRegistrationVM>>(registrations);
        }

        public async Task<ClassRegistrationVM> GetByIdAsync(int id)
        {
            var registration = await _context.ClassRegistrations.FindAsync(id);
            if (registration == null)
            {
                return null;
            }
            return _mapper.Map<ClassRegistrationVM>(registration);
        }

        public async Task<bool> CreateAsync(CreateClassRegistrationVM model)
        {
            var registration = new ClassRegistration
            {
                MemberId = model.MemberId,
                ClassId = model.ClassId
            };

            _context.ClassRegistrations.Add(registration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateClassRegistrationVM model)
        {
            var registration = await _context.ClassRegistrations.FindAsync(id);
            if (registration == null) return false;

            registration.MemberId = model.MemberId;
            registration.ClassId = model.ClassId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registration = await _context.ClassRegistrations.FindAsync(id);
            if (registration == null) return false;

            _context.ClassRegistrations.Remove(registration);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
