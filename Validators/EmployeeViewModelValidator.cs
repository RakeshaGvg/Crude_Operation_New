using Crude_Operation1.WEB.ViewModel;
using FluentValidation;

namespace Crude_Operation1.WEB.Validators
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(1, 50).WithMessage("First Name must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(1, 50).WithMessage("Last Name must be between 1 and 50 characters.");

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.")
                .Length(1, 100).WithMessage("Designation must be between 1 and 100 characters.");

            RuleFor(x => x.CreatedDate)
                .NotEmpty().WithMessage("Created Date is required.")
               .LessThanOrEqualTo(DateTime.Now).WithMessage("Created Date must be today or in the past.");
        }
    }
}