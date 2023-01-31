using FluentValidation;

namespace Test.Models.Validators
{
    public class FrequencyForWordRequestValidator:AbstractValidator<FrequencyForWordRequest>
    {
        public FrequencyForWordRequestValidator()
        {
            RuleFor(t => t.Text).NotNull().NotEmpty().MaximumLength(1000);
            RuleFor(t => t.Word).NotNull().NotEmpty().MaximumLength(1000);
        }
    }
}
