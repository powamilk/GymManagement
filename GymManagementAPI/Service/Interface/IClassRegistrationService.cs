using GymManagementAPI.ViewModel.ClassRegistrationVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IClassRegistrationService
    {
        Task<List<ClassRegistrationVM>> GetAllAsync();
        Task<ClassRegistrationVM> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateClassRegistrationVM model);
        Task<bool> UpdateAsync(int id, UpdateClassRegistrationVM model);
        Task<bool> DeleteAsync(int id);
    }
}
