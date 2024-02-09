namespace AEMOContracts
{
    using AEMOEntities;
    using AEMOEntities.Models;

    public interface IMatchRContract
    {
        public MatchTextModel? MatchRecursivly(MatchModel match, MatchTextModel matxhText);
    }
}
