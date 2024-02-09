namespace AEMORepository
{
    using AEMOContracts;
    using AEMOEntities.Models;

    public class FindStartRepository : IFindStartContract
    {
        public int FindStart(MatchModel match)
        {
            return match.MatchingText.IndexOf(match.SubText, match.IsCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
