namespace AEMOContracts
{
    using AEMOEntities.Models;

    public interface IFindStartContract
    {
        public int FindStart(MatchModel match, string matchingText);
    }
}
