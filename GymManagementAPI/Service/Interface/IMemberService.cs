using GymManagementAPI.ViewModel.MemberVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IMemberService
    {
        Task<List<MemberVM>> GetAllAsync();
        Task<MemberVM> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateMemberVM model);
        Task<bool> UpdateAsync(int id, UpdateMemberVM model);
        Task<bool> DeleteAsync(int id);
    }
}
