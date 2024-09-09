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
            CreateMap<Member, CreateMemberVM>();
            CreateMap<Member, UpdateMemberVM>();

            CreateMap<Trainer, TrainerVM>();
            CreateMap<Trainer, CreateTrainerVM>();
            CreateMap<Trainer, UpdateTrainerVM>();

            CreateMap<Class, ClassVM>();
            CreateMap<Class, CreateClassVM>();
            CreateMap<Class, UpdateClassVM>();

            CreateMap<ClassRegistration, ClassRegistrationVM>();
            CreateMap<ClassRegistration, CreateClassRegistrationVM>();
            CreateMap<ClassRegistration, UpdateClassRegistrationVM>();
        }
    }
}
