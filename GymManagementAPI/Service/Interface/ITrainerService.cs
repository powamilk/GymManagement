using GymManagementAPI.ViewModel.TrainerVM;

namespace GymManagementAPI.Service.Interface
{
    public interface ITrainerService
    {
        List<TrainerVM> GetAll();
        TrainerVM GetById(int id);
        bool Create(CreateTrainerVM model);
        bool Update(int id, UpdateTrainerVM model);
        bool Delete(int id);
    }
}
