using GymManagementAPI.ViewModel.ClassVM;

namespace GymManagementAPI.Service.Interface
{
    public interface IClassService
    {
        List<ClassVM> GetAll();
        ClassVM GetById(int id);
        bool Create(CreateClassVM model);
        bool Update(int id, UpdateClassVM model);
        bool Delete(int id);
    }
}
