namespace AEMO.Controllers
{
    using AEMOContracts;
    using AEMOEntities;
    using AEMOEntities.Models;
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
        public MatchTextModel? GetMatch(string text, string subText, bool multipleMatches, bool caseInsensitive)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subText))
            {
                return null;
            }

            var matchText = new MatchTextModel
            {
                StartOfSubtext = new List<int>(),
            };

            var match = new MatchModel { Text = text, SubText = subText, MultipleMatches = multipleMatches, IsCaseInsensitive = caseInsensitive, MatchingText = text};

            this._matchR.MatchRecursivly(match, matchText);

            return matchText;
        }
    }
}
