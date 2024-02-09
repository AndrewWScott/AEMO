namespace AEMORepository
{
    using AEMOContracts;

    public class FindStartRepository : IFindStartContract
    {
        public int FindStart(string text, string subText, bool caseInsensitive)
        {
            return text.IndexOf(subText, caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
