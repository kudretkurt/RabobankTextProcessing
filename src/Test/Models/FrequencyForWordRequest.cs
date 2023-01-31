namespace Test.Models
{
    public class FrequencyForWordRequest
    {

#pragma warning disable CS8618 // This prop is non nullable . We have validator class for this class.
        public string Text { get; set; }

        public string Word { get; set; }
#pragma warning restore CS8618 // This prop is non nullable . We have validator class for this class.
    }
}
