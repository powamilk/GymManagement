using FluentValidation;
using GymManagementAPI.ViewModel.TrainerVM;

namespace GymManagementAPI.ViewModel.Validator.TrainerValidator
{
    public class CreateTrainerVMValidator : AbstractValidator<CreateTrainerVM>
    {
        public CreateTrainerVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên không được để trống").MaximumLength(100).WithMessage("Tên tối đa 100 ký tự");
            RuleFor(x => x.Specialty).NotEmpty().WithMessage("Chuyên môn không được để trống").MaximumLength(50).WithMessage("Chuyên môn tối đa 50 ký tự");
            RuleFor(x => x.ExperienceYears).GreaterThanOrEqualTo(0).WithMessage("Số năm kinh nghiệm phải lớn hơn hoặc bằng 0");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống").EmailAddress().WithMessage("Địa chỉ email không hợp lệ");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Số điện thoại không được để trống").Matches(@"^\d+$").WithMessage("Số điện thoại chỉ chứa số").MaximumLength(15).WithMessage("Số điện thoại tối đa 15 ký tự");
        }
    }
}
