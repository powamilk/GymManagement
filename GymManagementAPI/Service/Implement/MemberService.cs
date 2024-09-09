using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.MemberVM;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<MemberVM>> GetAllAsync()
        {
            var membersQuery = _context.Members.AsQueryable();
            var members = await membersQuery.ToListAsync();
            return _mapper.Map<List<MemberVM>>(members);
        }

        public async Task<MemberVM> GetByIdAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return null;
            }
            return _mapper.Map<MemberVM>(member);
        }

        public async Task<bool> CreateAsync(CreateMemberVM model)
        {
            var memberEntity = new Member
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                MembershipType = model.MembershipType,
                JoinDate = model.JoinDate
            };

            _context.Members.Add(memberEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMemberVM model)
        {
            var memberEntity = await _context.Members.FindAsync(id);
            if (memberEntity == null) return false;
            memberEntity.Name = model.Name;
            memberEntity.Email = model.Email;
            memberEntity.Phone = model.Phone;
            memberEntity.MembershipType = model.MembershipType;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var memberEntity = await _context.Members.FindAsync(id);
            if (memberEntity == null) return false;

            _context.Members.Remove(memberEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
