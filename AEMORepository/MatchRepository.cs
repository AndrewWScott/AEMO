namespace AEMORepository
{
    using AEMOContracts;
    using AEMOEntities;
    using AEMOEntities.Models;

    public class MatchRepository : IMatchContract
    {
        private readonly IContainsContract _match;
#pragma warning disable SA1309 // Field names should not begin with underscore
        private readonly IFindStartContract _findStart;
#pragma warning restore SA1309 // Field names should not begin with underscore

        public MatchRepository(IContainsContract matchContract, IFindStartContract findStart)
        {
            this._match = matchContract;
            this._findStart = findStart;
        }

        public MatchTextModel? Match(MatchModel match)
        {
            var matchText = new MatchTextModel
            {
                Match = false,
                StartOfSubtext = new List<int>(),
            };

            while (this._match.Contains(match, match.Text))
            {
                matchText.Match = true;

                // find position
                int positionOf = this._findStart.FindStart(match, match.Text);

                // increment for a 1 starting number
                positionOf++;

                // add found position to list
                matchText?.StartOfSubtext?.Add(positionOf + matchText.StartOfSubtext.LastOrDefault());

                // stop if single match or outside string
                if (!match.HasMultipleMatches || positionOf >= match.Text.Length)
                {
                    return matchText;
                }

                // get next string to search for
                match.Text = match.Text.Substring(positionOf);
            }

            return matchText;
        }
    }
}
