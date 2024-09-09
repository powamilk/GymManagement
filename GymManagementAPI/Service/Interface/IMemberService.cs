using GymManagementAPI.ViewModel.MemberVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IMemberService
    {
        List<MemberVM> GetAll();
        MemberVM GetById(int id);
        bool Create(CreateMemberVM model);
        bool Update(int id, UpdateMemberVM model);
        bool Delete(int id);
    }
}
