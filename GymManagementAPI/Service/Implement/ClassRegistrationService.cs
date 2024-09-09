using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassRegistrationVM;

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

        public List<ClassRegistrationVM> GetAll()
        {
            var registrations = _context.ClassRegistrations.ToList();
            return _mapper.Map<List<ClassRegistrationVM>>(registrations);
        }

        public ClassRegistrationVM GetById(int id)
        {
            var registration = _context.ClassRegistrations.Find(id);
            if (registration == null) return null;
            return _mapper.Map<ClassRegistrationVM>(registration);
        }

        public bool Create(CreateClassRegistrationVM model)
        {
            var registration = new ClassRegistration
            {
                MemberId = model.MemberId,
                ClassId = model.ClassId
            };

            _context.ClassRegistrations.Add(registration);
            _context.SaveChanges();
            return true;
        }

        public bool Update(int id, UpdateClassRegistrationVM model)
        {
            var registration = _context.ClassRegistrations.Find(id);
            if (registration == null) return false;
            registration.MemberId = model.MemberId;
            registration.ClassId = model.ClassId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var registration = _context.ClassRegistrations.Find(id);
            if (registration == null) return false;

            _context.ClassRegistrations.Remove(registration);
            _context.SaveChanges();
            return true;
        }
    }
}
