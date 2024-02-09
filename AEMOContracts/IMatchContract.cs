namespace AEMOContracts
{
    public interface IMatchContract
    {
        public bool Match(string text, string subText, bool caseInsensitive);
    }
}
