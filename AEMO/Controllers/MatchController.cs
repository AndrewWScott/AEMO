namespace AEMO.Controllers
{
    using AEMOContracts;
    using AEMOEntities;
    using Microsoft.AspNetCore.Mvc;
    using static System.Net.Mime.MediaTypeNames;

    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRContract _matchR;

        public MatchController(IMatchRContract matchR)
        {
            this._matchR = matchR;
        }

        [HttpGet(Name = "GetMatch")]
        public MatchTextModel GetMatch(string text, string subText, bool multipleMatches, bool caseInsensitive)
        {
            var matchText = new MatchTextModel
            {
                StartOfSubtext = new List<int>(),
            };

            this._matchR.MatchRecursivly(text, subText, caseInsensitive, multipleMatches, matchText, text);

            return matchText;
        }
    }
}
