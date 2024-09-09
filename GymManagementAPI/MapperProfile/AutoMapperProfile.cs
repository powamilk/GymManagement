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
            CreateMap<CreateMemberVM, Member>();
            CreateMap<UpdateMemberVM, Member>();

            CreateMap<Trainer, TrainerVM>();
            CreateMap<CreateTrainerVM, Trainer>();
            CreateMap<UpdateTrainerVM, Trainer>();

            CreateMap<Class, ClassVM>();
            CreateMap<CreateClassVM, Class>();
            CreateMap<UpdateClassVM, Class>();

            CreateMap<ClassRegistration, ClassRegistrationVM>();
            CreateMap<CreateClassRegistrationVM, ClassRegistration>();
            CreateMap<UpdateClassRegistrationVM, ClassRegistration>();
        }
    }
}
