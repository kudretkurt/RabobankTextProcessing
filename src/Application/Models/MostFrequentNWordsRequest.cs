namespace Test.Models
{
    public class MostFrequentNWordsRequest
    {
#pragma warning disable CS8618 // This prop is non nullable . We have validator class for this class.
        public string Text { get; set; }
        public int MostFrequentMaxWordCount { get; set; }
    }
}
