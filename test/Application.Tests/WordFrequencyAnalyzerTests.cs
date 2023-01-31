namespace Test.UnitTests
{
    public class WordFrequencyAnalyzerTests
    {
        private readonly WordFrequencyAnalyzer _sut = new();

        #region [ CalculateFrequencyForWord ]

        [Theory,
         InlineData(null, null),
         InlineData(null, ""),
         InlineData(null, "kudret"),
         InlineData("", null),
         InlineData("", ""),
         InlineData("", "kudret"),
         InlineData("kurtet", "kudret"),
         InlineData("weather is so beautiful", "kudret"),
         InlineData("smile smile more smile", "kudret"),
         InlineData("!!@ ##$ ##@ kudr@, kklk", "kudret")]
        public void GivenCalculateFrequencyForWord_WhenTextDoesNotContainRightWord_ShouldReturnZero(string text, string word)
        {
            // Arrange

            // Act
            var result = _sut.CalculateFrequencyForWord(text, word);

            // Assert
            result.Should().Be(0);
        }


        [Theory,
        InlineData(null, null),
        InlineData(null, ""),
        InlineData(null, "kudret"),
        InlineData("", null),
        InlineData("", ""),
        InlineData("", "kudret"),
        InlineData("kurtet", "kudret"),
        InlineData("weather is so beautiful", "kudret"),
        InlineData("smile smile more smile", "kudret"),
        InlineData("!!@ ##$ ##@ kudr@, kklk", "kudret")]
        public async Task GivenCalculateFrequencyForWordAsync_WhenTextDoesNotContainRightWord_ShouldReturnZero(string text, string word)
        {
            // Arrange

            // Act
            var result = await _sut.CalculateFrequencyForWordAsync(text, word);

            // Assert
            result.Should().Be(0);
        }

        [Theory,
         InlineData("kudret", "kudret", 1),
         InlineData("My kudret.", "kudret", 1),
         InlineData("My kudret is my kudret.", "kudret", 2),
         InlineData("kudret and KUdret and KuDrEt and KUDRET.", "kudret", 4),
         InlineData("The kudret is 32 years old.", "kudret", 1)]
        public void GivenCalculateFrequencyForWord_WhenTextContainsRightWord_ShouldReturnsCount(string text, string word, int count)
        {
            // Arrange

            // Act
            var result = _sut.CalculateFrequencyForWord(text, word);

            // Assert
            result.Should().Be(count);
        }

        [Theory,
         InlineData("kudret", "kudret", 1),
         InlineData("My kudret.", "kudret", 1),
         InlineData("My kudret is my kudret.", "kudret", 2),
         InlineData("kudret and KUdret and KuDrEt and KUDRET.", "kudret", 4),
         InlineData("The kudret is 32 years old.", "kudret", 1)]
        public async Task GivenCalculateFrequencyForWordAsync_WhenTextContainsRightWord_ShouldReturnsCount(string text, string word, int count)
        {
            // Arrange

            // Act
            var result = await _sut.CalculateFrequencyForWordAsync(text, word);

            // Assert
            result.Should().Be(count);
        }

        #endregion

        #region [ CalculateHighestFrequency ]

        [Theory,
         InlineData(null, 0),
         InlineData("", 0),
         InlineData("kudret", 1),
         InlineData("kudret and kurtet", 1),
         InlineData("the kudret can not speak dutch", 1),
         InlineData("My kudret is my kudret.", 2),
         InlineData("kudret and KuDrEt and KUDRET and kuDRet.", 4)]
        public void GivenCalculateHighestFrequency_WhenTextIsProvided_ShouldReturnsHighestFrequency(string text, int frequencyCount)
        {
            // Arrange

            // Act
            var result = _sut.CalculateHighestFrequency(text);

            // Assert
            result.Should().Be(frequencyCount);
        }

        [Theory,
        InlineData(null, 0),
        InlineData("", 0),
        InlineData("kudret", 1),
        InlineData("kudret and kurtet", 1),
        InlineData("the kudret can not speak dutch", 1),
        InlineData("My kudret is my kudret.", 2),
        InlineData("kudret and KuDrEt and KUDRET and kuDRet.", 4)]
        public async Task GivenCalculateHighestFrequencyAsync_WhenTextIsProvided_ShouldReturnsHighestFrequency(string text, int frequencyCount)
        {
            // Arrange

            // Act
            var result = await _sut.CalculateHighestFrequencyAsync(text);

            // Assert
            result.Should().Be(frequencyCount);
        }

        #endregion

        #region [ CalculateMostFrequentNWords ]

        [Fact]
        public void GivenCalculateMostFrequentNWords_WhenProvidedTestcaseIsRun_ThenResultsAreAsDescribed()
        {
            // Arrange
            var text = "I don't drink coffee " +
                " I take tea, my dear " +
                "I like my toast done on one side " +
                "And you can hear it in my accent when I talk " +
                "I am an Englishman in New York " +
                "See me walking down Fifth Avenue " +
                "A walking cane here at my side " +
                "I take it everywhere I walk " +
                "I am an Englishman in New York ";
            var n = 3;

            // Act
            var result = _sut.CalculateMostFrequentNWords(text, n);

            // Assert
            result.Should().HaveCount(3);
            result[0].Word.Should().Be("i");
            result[0].Frequency.Should().Be(8);
            result[1].Word.Should().Be("my");
            result[1].Frequency.Should().Be(4);
            result[2].Word.Should().Be("in");
            result[2].Frequency.Should().Be(3);
        }

        [Fact]
        public async Task GivenCalculateMostFrequentNWordsAsync_WhenProvidedTestcaseIsRun_ThenResultsAreAsDescribed()
        {
            // Arrange
            var text = "I don't drink coffee " +
                " I take tea, my dear " +
                "I like my toast done on one side " +
                "And you can hear it in my accent when I talk " +
                "I am an Englishman in New York " +
                "See me walking down Fifth Avenue " +
                "A walking cane here at my side " +
                "I take it everywhere I walk " +
                "I am an Englishman in New York ";
            var n = 3;

            // Act
            var result = await _sut.CalculateMostFrequentNWordsAsync(text, n);

            // Assert
            result.Should().HaveCount(3);
            result[0].Word.Should().Be("i");
            result[0].Frequency.Should().Be(8);
            result[1].Word.Should().Be("my");
            result[1].Frequency.Should().Be(4);
            result[2].Word.Should().Be("in");
            result[2].Frequency.Should().Be(3);
        }

        #endregion
    }
}