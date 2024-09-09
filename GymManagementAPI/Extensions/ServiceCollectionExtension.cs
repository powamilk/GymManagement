using FluentValidation;
using GymManagementAPI.MapperProfile;
using GymManagementAPI.Service.Implement;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.Validator.ClassRegistrationValidator;
using GymManagementAPI.Validator.ClassValidator;
using GymManagementAPI.Validator.MemberValidator;
using GymManagementAPI.Validator.TrainerValidator;
using GymManagementAPI.ViewModel.ClassRegistrationVM;
using GymManagementAPI.ViewModel.ClassVM;
using GymManagementAPI.ViewModel.MemberVM;
using GymManagementAPI.ViewModel.TrainerVM;

namespace GymManagementAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClassRegistrationService, ClassRegistrationService>();

            return services;
        }

        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateMemberVM>, CreateMemberVMValidator>();
            services.AddScoped<IValidator<UpdateMemberVM>, UpdateMemberVMValidator>();
            services.AddScoped<IValidator<CreateTrainerVM>, CreateTrainerVMValidator>();
            services.AddScoped<IValidator<UpdateTrainerVM>, UpdateTrainerVMValidator>();
            services.AddScoped<IValidator<CreateClassVM>, CreateClassVMValidator>();
            services.AddScoped<IValidator<UpdateClassVM>, UpdateClassVMValidator>();
            services.AddScoped<IValidator<CreateClassRegistrationVM>, CreateClassRegistrationVMValidator>();
            services.AddScoped<IValidator<UpdateClassRegistrationVM>, UpdateClassRegistrationVMValidator>();

            return services;
        }

        public static IServiceCollection AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile(new AutoMapperProfile()));
            return services;
        }
    }
}
