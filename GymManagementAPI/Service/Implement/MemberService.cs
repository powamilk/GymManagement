using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.MemberVM;

namespace GymManagementAPI.Service.Implement
{
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MemberService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MemberVM> GetAll()
        {
            var members = _context.Members.ToList();
            return _mapper.Map<List<MemberVM>>(members);
        }

        public MemberVM GetById(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null) return null;
            return _mapper.Map<MemberVM>(member);
        }

        public bool Create(CreateMemberVM model)
        {
            var member = _mapper.Map<Member>(model);
            _context.Members.Add(member);
            _context.SaveChanges();
            return true;
        }

        public bool Update(int id, UpdateMemberVM model)
        {
            var member = _context.Members.Find(id);
            if (member == null) return false;
            _mapper.Map(model, member);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null) return false;
            _context.Members.Remove(member);
            _context.SaveChanges();
            return true;
        }
    }
}
