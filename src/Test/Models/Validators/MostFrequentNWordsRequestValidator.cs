using FluentValidation;

namespace Test.Models.Validators
{
    public class MostFrequentNWordsRequestValidator:AbstractValidator<MostFrequentNWordsRequest>
    {
        public MostFrequentNWordsRequestValidator()
        {
            RuleFor(t=>t.Text).NotNull().NotEmpty().MaximumLength(1000); ;
            RuleFor(t => t.MostFrequentMaxWordCount).NotNull().GreaterThanOrEqualTo(1);
        }
    }
}
