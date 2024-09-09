using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.TrainerVM;

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

        public List<TrainerVM> GetAll()
        {
            var trainers = _context.Trainers.ToList();
            return _mapper.Map<List<TrainerVM>>(trainers);
        }

        public TrainerVM GetById(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return null;
            return _mapper.Map<TrainerVM>(trainer);
        }

        public bool Create(CreateTrainerVM model)
        {
            var trainer = _mapper.Map<Trainer>(model);
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
            return true;
        }

        public bool Update(int id, UpdateTrainerVM model)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return false;
            _mapper.Map(model, trainer);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return false;
            _context.Trainers.Remove(trainer);
            _context.SaveChanges();
            return true;
        }
    }
}
