namespace AEMORepository
{
    using AEMOContracts;
    using AEMOEntities.Models;

    public class FindStartRepository : IFindStartContract
    {
        public int FindStart(MatchModel match, string matchingText)
        {
            return matchingText.IndexOf(match.SubText, match.IsCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
