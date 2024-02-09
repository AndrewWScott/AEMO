using AEMO.Controllers;
using AEMOContracts;
using AEMOEntities;
using AEMOEntities.Models;
using AEMORepository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Sdk;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AEMOTests
{
    [TestClass]
    public class MatchTest
    {
        IServiceCollection services = new ServiceCollection();
        public MatchTest() 
        {            
            services.AddScoped<IMatchContract, MatchRepository>();
        }

        [TestMethod]
        public void Match()
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var matchService = serviceProvider.GetRequiredService<IMatchContract>();

                string Text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel _MatchCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, MultipleMatches = true, MatchingText = Text };
                MatchModel _NoMatchCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, MultipleMatches = true, MatchingText = Text };

                MatchModel _MatchNCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, MultipleMatches = true, MatchingText = Text };
                MatchModel _NoMatchNCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, MultipleMatches = true, MatchingText = Text };

                MatchModel _MatchCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, MultipleMatches = false, MatchingText = Text };
                MatchModel _NoMatchCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, MultipleMatches = false, MatchingText = Text };

                MatchModel _MatchNCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, MultipleMatches = false, MatchingText = Text };
                MatchModel _NoMatchNCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, MultipleMatches = false, MatchingText = Text };

                Assert.IsTrue(matchService.Match(_MatchCSMM));
                Assert.IsFalse(matchService.Match(_NoMatchCSMM));

                Assert.IsTrue(matchService.Match(_MatchNCSMM));
                Assert.IsFalse(matchService.Match(_NoMatchNCSMM));

                Assert.IsTrue(matchService.Match(_MatchCSSM));
                Assert.IsFalse(matchService.Match(_NoMatchCSSM));

                Assert.IsTrue(matchService.Match(_MatchNCSSM));
                Assert.IsFalse(matchService.Match(_NoMatchNCSSM));
            }            
        }
    }
}