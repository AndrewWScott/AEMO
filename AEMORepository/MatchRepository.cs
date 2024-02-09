namespace AEMORepository
{
    public class MatchRepository : AEMOContracts.IMatchContract
    {
        public bool Match(string text, string subText, bool caseInsensitive)
        {
            return text.Contains(subText, caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
