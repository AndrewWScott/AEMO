using AEMOEntities.Models;

namespace AEMOContracts
{
    public interface IMatchContract
    {
        public bool Match(MatchModel match);
    }
}
