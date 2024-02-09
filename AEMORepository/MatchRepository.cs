namespace AEMORepository
{
    using AEMOEntities.Models;

    public class MatchRepository : AEMOContracts.IMatchContract
    {
        public bool Match(MatchModel match)
        {
            return match.MatchingText.Contains(match.SubText, match.IsCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
