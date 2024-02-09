namespace AEMORepository
{
    using AEMOContracts;
    using AEMOEntities;

    public class MatchR : IMatchRContract
    {
#pragma warning disable SA1309 // Field names should not begin with underscore
        private readonly IMatchContract _match;
#pragma warning restore SA1309 // Field names should not begin with underscore
        private readonly IFindStartContract _findStart;

        public MatchR(IMatchContract matchContract, IFindStartContract findStart)
        {
            this._match = matchContract;
            this._findStart = findStart;
        }

        public MatchTextModel? MatchRecursivly(string text, string subText, bool caseInsensitive, bool multipleMatches, MatchTextModel matchText, string initalText)
        {
            if (!this._match.Match(text, subText, caseInsensitive))
            {
                return matchText;
            }

            matchText.Match = true;

            int positionOf = this._findStart.FindStart(text, subText, caseInsensitive);

            // increment for a 1 starting number
            positionOf++;

            // add found position to list
            matchText?.StartOfSubtext?.Add(positionOf + matchText.StartOfSubtext.LastOrDefault());

            // stop if single match
            if (!multipleMatches)
            {
                return matchText;
            }

            // get next string to search for
            text = initalText.Substring((int)matchText?.StartOfSubtext?.LastOrDefault());

            this.MatchRecursivly(text, subText, caseInsensitive, multipleMatches, matchText, initalText);

            return matchText;
        }
    }
}
