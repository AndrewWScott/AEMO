namespace AEMOContracts
{
    using AEMOEntities;
    using AEMOEntities.Models;

    public interface IMatchContract
    {
        public MatchTextModel? Match(MatchModel match);
    }
}
