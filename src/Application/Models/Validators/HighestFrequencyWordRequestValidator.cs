using FluentValidation;

namespace Test.Models.Validators
{
    public class HighestFrequencyWordRequestValidator : AbstractValidator<HighestFrequencyWordRequest>
    {
        public HighestFrequencyWordRequestValidator()
        {
            RuleFor(t => t.Text).NotNull().NotEmpty().MaximumLength(1000);
        }
    }
}
