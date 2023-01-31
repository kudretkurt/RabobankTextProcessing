using System.Text.RegularExpressions;

namespace Test
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        /// <summary>
        /// You can get frequency count for any word which is in the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns>int</returns>
        public int CalculateFrequencyForWord(string text, string word)
        {
            if(string.IsNullOrWhiteSpace(word)) return 0;
            word=word.Trim();
            var item = SeperateWordsFromText(text).SingleOrDefault(x => x.Key == word);
            return item.Value;
        }

        /// <summary>
        /// You can get frequency count for any word which is in the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns>Task<int></returns>
        public async Task<int> CalculateFrequencyForWordAsync(string text, string word)
        {
            return await Task.FromResult(CalculateFrequencyForWord(text, word));
        }

        /// <summary>
        /// You can get highest frequency number in the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>int</returns>
        public int CalculateHighestFrequency(string text)
        {
            var highest = SeperateWordsFromText(text).OrderByDescending(x => x.Value).FirstOrDefault();
            return highest.Value;
        }


        /// <summary>
        /// You can get highest frequency number in the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns> Task<int></returns>
        public async Task<int> CalculateHighestFrequencyAsync(string text)
        {
            return await Task.FromResult(CalculateHighestFrequency(text));
        }

        /// <summary>
        /// You can get list  which is include word and frequency number .If several words have the same frequency, this method return them in ascendant alphabetical order.This list's item count will be until the n number
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            var items = SeperateWordsFromText(text)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(n)
                .Select(x => new WordFrequency(x.Key, x.Value) as IWordFrequency);
            return items.ToList();
        }

        /// <summary>
        /// You can get list  which is include word and frequency number .If several words have the same frequency, this method return them in ascendant alphabetical order.This list's item count will be until the n number
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public async Task<IList<IWordFrequency>> CalculateMostFrequentNWordsAsync(string text, int n)
        {
            return await Task.FromResult(CalculateMostFrequentNWords(text, n));
        }

        private Dictionary<string, int> SeperateWordsFromText(string text)
        {
            var collection = new Dictionary<string, int>();
            if (!string.IsNullOrWhiteSpace(text))
            {
                var words = Regex.Matches(text, @"\b[a-z]+\b", RegexOptions.IgnoreCase);
                foreach (var match in words.Cast<Match>())
                {
                    var word = match.Value.ToLowerInvariant();
                    if (!collection.ContainsKey(word))
                    {
                        collection.Add(word, 0);
                    }
                    collection[word]++;
                }
            }

            return collection;
        }
    }
}
