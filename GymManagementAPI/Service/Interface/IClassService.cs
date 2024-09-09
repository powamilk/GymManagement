using GymManagementAPI.ViewModel.ClassVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IClassService
    {
        Task<List<ClassVM>> GetAllAsync();
        Task<ClassVM> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateClassVM model);
        Task<bool> UpdateAsync(int id, UpdateClassVM model);
        Task<bool> DeleteAsync(int id);
    }
}
