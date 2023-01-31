namespace Test
{
    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);
        Task<int> CalculateHighestFrequencyAsync(string text);
        int CalculateFrequencyForWord(string text, string word);
        Task<int> CalculateFrequencyForWordAsync(string text, string word);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
        Task<IList<IWordFrequency>> CalculateMostFrequentNWordsAsync(string text, int n);
    }
}