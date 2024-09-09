using FluentValidation;
using GymManagementAPI.ViewModel.ClassRegistrationVM;

namespace GymManagementAPI.ViewModel.Validator.ClassRegistrationValidator
{
    public class UpdateClassRegistrationVMValidator : AbstractValidator<UpdateClassRegistrationVM>
    {
        public UpdateClassRegistrationVMValidator()
        {
            RuleFor(x => x.MemberId).GreaterThan(0).WithMessage("Thành viên không hợp lệ");
            RuleFor(x => x.ClassId).GreaterThan(0).WithMessage("Lớp học không hợp lệ");
        }
    }
}
