using GymManagementAPI.ViewModel.ClassRegistrationVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IClassRegistrationService
    {
        List<ClassRegistrationVM> GetAll();
        ClassRegistrationVM GetById(int id);
        bool Create(CreateClassRegistrationVM model);
        bool Update(int id, UpdateClassRegistrationVM model);
        bool Delete(int id);
    }
}
