using FluentValidation;
using GymManagementAPI.ViewModel.MemberVM;

namespace GymManagementAPI.ViewModel.Validator.MemberValidator
{
    public class UpdateMemberVMValidator : AbstractValidator<UpdateMemberVM>
    {
        public UpdateMemberVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên không được để trống").MaximumLength(100).WithMessage("Tên tối đa 100 ký tự");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống").EmailAddress().WithMessage("Địa chỉ email không hợp lệ");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Số điện thoại không được để trống").Matches(@"^\d+$").WithMessage("Số điện thoại chỉ chứa số").MaximumLength(15).WithMessage("Số điện thoại tối đa 15 ký tự");
            RuleFor(x => x.MembershipType).NotEmpty().WithMessage("Loại thẻ thành viên không được để trống").Must(type => type == "Basic" || type == "Premium").WithMessage("Loại thẻ không hợp lệ");
            RuleFor(x => x.JoinDate).NotEmpty().WithMessage("Ngày tham gia không được để trống");
        }
    }
}
