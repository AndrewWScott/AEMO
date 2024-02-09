namespace AEMOContracts
{
    using AEMOEntities.Models;

    public interface IMatchContract
    {
        public bool Match(MatchModel match);
    }
}
