using GymManagementAPI.ViewModel.ClassVM;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using AutoMapper;

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

        public List<ClassVM> GetAll()
        {
            var classes = _context.Classes.ToList();
            return _mapper.Map<List<ClassVM>>(classes);
        }

        public ClassVM GetById(int id)
        {
            var classEntity = _context.Classes.Find(id);
            if (classEntity == null) return null;
            return _mapper.Map<ClassVM>(classEntity);
        }

        public bool Create(CreateClassVM model)
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
            _context.SaveChanges();
            return true;
        }

        public bool Update(int id, UpdateClassVM model)
        {
            var classEntity = _context.Classes.Find(id);
            if (classEntity == null) return false;
            classEntity.Name = model.Name;
            classEntity.TrainerId = model.TrainerId;
            classEntity.Schedule = model.Schedule;
            classEntity.MaxMembers = model.MaxMembers;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var classEntity = _context.Classes.Find(id);
            if (classEntity == null) return false;

            _context.Classes.Remove(classEntity);
            _context.SaveChanges();
            return true;
        }
    }
}
