using GymManagementAPI.ViewModel.TrainerVM;

namespace GymManagementAPI.Service.Interface
{
    public interface ITrainerService
    {
        Task<List<TrainerVM>> GetAllAsync();
        Task<TrainerVM> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateTrainerVM model);
        Task<bool> UpdateAsync(int id, UpdateTrainerVM model);
        Task<bool> DeleteAsync(int id);
    }
}
