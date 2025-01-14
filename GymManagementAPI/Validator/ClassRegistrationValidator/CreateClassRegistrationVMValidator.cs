﻿using FluentValidation;
using GymManagementAPI.ViewModel.ClassRegistrationVM;

namespace GymManagementAPI.Validator.ClassRegistrationValidator
{
    public class CreateClassRegistrationVMValidator : AbstractValidator<CreateClassRegistrationVM>
    {
        public CreateClassRegistrationVMValidator()
        {
            RuleFor(x => x.MemberId)
            .GreaterThan(0).WithMessage("Thành viên không hợp lệ");

            RuleFor(x => x.ClassId)
                .GreaterThan(0).WithMessage("Lớp học không hợp lệ");
        }
    }
}
