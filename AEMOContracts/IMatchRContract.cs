namespace AEMOContracts
{
    using AEMOEntities;

    public interface IMatchRContract
    {
        public MatchTextModel? MatchRecursivly(string text, string subText, bool caseInsensitive, bool multipleMatches, MatchTextModel matchText, string initalText);
    }
}
