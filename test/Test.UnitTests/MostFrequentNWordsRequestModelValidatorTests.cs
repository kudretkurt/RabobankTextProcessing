using Test.Models.Validators;
using Test.Models;

namespace Test.UnitTests
{
    public class MostFrequentNWordsRequestModelValidatorTests
    {
        private readonly MostFrequentNWordsRequestValidator _sut = new();


        [Theory,
        InlineData(null, -1),
        InlineData(null, 0),
        InlineData("", 0),
        InlineData("", -1)]
        public void GivenMostFrequentNWordsRequest_WhenTextAndCountIsNotProper_ShouldHaveException(string text, int mostFrequentMaxWordCount)
        {
            // Arrange
            var request = new MostFrequentNWordsRequest() { Text = text, MostFrequentMaxWordCount = mostFrequentMaxWordCount };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
            act.ShouldHaveValidationErrorFor(x => x.MostFrequentMaxWordCount);
        }

        [Fact]
        public void GivenMostFrequentNWordsRequest_WhenTextLengthGreaterThan1000_ShouldHaveException()
        {
            // Arrange
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 101; i++)
            {
                stringBuilder.Append("abcdefghi ");
            }

            var request = new MostFrequentNWordsRequest() { Text = stringBuilder.ToString() };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
        }
    }
}
