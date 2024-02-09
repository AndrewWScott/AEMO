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
#pragma warning disable SA1309 // Field names should not begin with underscore
        private readonly IMatchContract _matchR;
#pragma warning restore SA1309 // Field names should not begin with underscore

        public MatchController(IMatchContract matchR)
        {
            this._matchR = matchR;
        }

        [HttpGet(Name = "GetMatch")]
        public MatchTextModel? GetMatch([FromQuery] MatchModel match)
        {
            return this._matchR.Match(match);
        }
    }
}
