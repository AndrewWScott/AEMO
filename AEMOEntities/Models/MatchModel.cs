namespace AEMOEntities.Models
{
    public class MatchModel
    {
        public required string Text { get; set; }

        public required string SubText { get; set; }

        public bool IsCaseInsensitive { get; set; }

        public bool HasMultipleMatches { get; set; }

        public string? MatchingText { get; set; }
    }
}
