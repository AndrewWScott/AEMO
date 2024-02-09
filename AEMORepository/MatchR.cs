namespace AEMORepository
{
    using AEMOContracts;
    using AEMOEntities;
    using AEMOEntities.Models;

    public class MatchR : IMatchRContract
    {
        private readonly IMatchContract _match;
#pragma warning disable SA1309 // Field names should not begin with underscore
        private readonly IFindStartContract _findStart;
#pragma warning restore SA1309 // Field names should not begin with underscore

        public MatchR(IMatchContract matchContract, IFindStartContract findStart)
        {
            this._match = matchContract;
            this._findStart = findStart;
        }

        public MatchTextModel? MatchRecursivly(MatchModel? match, MatchTextModel? matchText)
        {
            if (match is null || matchText is null)
            {
                return null;
            }

            if (!this._match.Match(match))
            {
                return matchText;
            }

            matchText.Match = true;

            int positionOf = this._findStart.FindStart(match);

            // increment for a 1 starting number
            positionOf++;

            // add found position to list
            matchText?.StartOfSubtext?.Add(positionOf + matchText.StartOfSubtext.LastOrDefault());

            // get next string to search for
            match.MatchingText = match?.Text?.Substring(matchText.StartOfSubtext.LastOrDefault());

            // stop if single match or MatchingText is Empty
            if (!match.MultipleMatches || string.IsNullOrEmpty(match.MatchingText))
            {
                return matchText;
            }

            this.MatchRecursivly(match, matchText);

            return matchText;
        }
    }
}
