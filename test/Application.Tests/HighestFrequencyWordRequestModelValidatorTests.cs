
 using Test.Models.Validators;
 using Test.Models;

namespace Test.UnitTests
{
    public class HighestFrequencyWordRequestModelValidatorTests
    {
        private readonly HighestFrequencyWordRequestValidator _sut = new();


        [Theory,
        InlineData(null),
        InlineData("")]
        public void GivenHighestFrequencyWordRequest_WhenTextIsNullOrEmpty_ShouldHaveException(string text)
        {
            // Arrange
            var request = new HighestFrequencyWordRequest() { Text = text };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Fact]
        public void GivenHighestFrequencyWordRequest_WhenTextLengthGreaterThan1000_ShouldHaveException()
        {
            // Arrange
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 101; i++)
            {
                stringBuilder.Append("abcdefghi ");
            }

            var request = new HighestFrequencyWordRequest() { Text = stringBuilder.ToString() };

            // Act
            var act = _sut.TestValidate(request);

            // Assert
            Assert.False(act.IsValid);
            act.ShouldHaveValidationErrorFor(x => x.Text);
        }
    }
}
