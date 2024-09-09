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
            var member = new Member
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                MembershipType = model.MembershipType,
                JoinDate = model.JoinDate
            };

            _context.Members.Add(member);
            _context.SaveChanges();
            return true;
        }

        public bool Update(int id, UpdateMemberVM model)
        {
            var member = _context.Members.Find(id);
            if (member == null) return false;
            member.Name = model.Name;
            member.Email = model.Email;
            member.Phone = model.Phone;
            member.MembershipType = model.MembershipType;
            member.JoinDate = model.JoinDate;

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
