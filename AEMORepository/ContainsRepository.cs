namespace AEMORepository
{
    using AEMOEntities.Models;

    public class ContainsRepository : AEMOContracts.IContainsContract
    {
        public bool Contains(MatchModel match, string matchingText)
        {
            return matchingText.Contains(match.SubText, match.IsCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
