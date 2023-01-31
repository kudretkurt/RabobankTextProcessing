using Test.Models.Validators;
using Test.Models;

namespace Test.UnitTests
{
    public class FrequencyForWordRequestModelValidatorTests
    {
        private readonly FrequencyForWordRequestValidator _sut = new();


        [Theory,
        InlineData(null, null),
        InlineData(null, ""),
        InlineData("", null),
        InlineData("", "")]
        public void GivenFrequencyForWordRequest_WhenTextAndWordIsNullOrEmpty_ShouldHaveException(string text, string word)
        {
            // Arrange
            var request = new FrequencyForWordRequest() { Text = text, Word = word };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
            act.ShouldHaveValidationErrorFor(x => x.Word);
        }

        [Fact]
        public void GivenFrequencyForWordRequest_WhenTextAndWordLengthGreaterThan1000_ShouldHaveException()
        {
            // Arrange
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 101; i++)
            {
                stringBuilder.Append("abcdefghi ");
            }

            var request = new FrequencyForWordRequest() { Text = stringBuilder.ToString(), Word = stringBuilder.ToString() };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
            act.ShouldHaveValidationErrorFor(x => x.Word);
        }
    }
}
