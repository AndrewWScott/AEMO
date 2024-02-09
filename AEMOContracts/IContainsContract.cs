namespace AEMOContracts
{
    using AEMOEntities.Models;

    public interface IContainsContract
    {
        public bool Contains(MatchModel match, string matchingText);
    }
}
