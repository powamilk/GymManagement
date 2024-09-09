using AutoMapper;
using GymManagementAPI.Entities;
using GymManagementAPI.ViewModel.ClassRegistrationVM;
using GymManagementAPI.ViewModel.ClassVM;
using GymManagementAPI.ViewModel.MemberVM;
using GymManagementAPI.ViewModel.TrainerVM;

namespace GymManagementAPI.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Member, MemberVM>();
            CreateMap<Trainer, TrainerVM>();
            CreateMap<Class, ClassVM>();
            CreateMap<ClassRegistration, ClassRegistrationVM>();
        }
    }
}
