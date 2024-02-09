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
    public class ContainsTest
    {
        IServiceCollection services = new ServiceCollection();
        public ContainsTest() 
        {            
            services.AddScoped<IContainsContract, ContainsRepository>();
        }

        [TestMethod]
        public void Contains()
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var matchService = serviceProvider.GetRequiredService<IContainsContract>();

                string Text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel _MatchCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true };
                MatchModel _NoMatchCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true};

                MatchModel _MatchNCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel _NoMatchNCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel _MatchCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel _NoMatchCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel _MatchNCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel _NoMatchNCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                Assert.IsTrue(matchService.Contains(_MatchCSMM, _MatchCSMM.Text));
                Assert.IsFalse(matchService.Contains(_NoMatchCSMM, _NoMatchCSMM.Text));

                Assert.IsTrue(matchService.Contains(_MatchNCSMM, _MatchNCSMM.Text));
                Assert.IsFalse(matchService.Contains(_NoMatchNCSMM, _NoMatchNCSMM.Text));

                Assert.IsTrue(matchService.Contains(_MatchCSSM, _MatchCSSM.Text));
                Assert.IsFalse(matchService.Contains(_NoMatchCSSM, _NoMatchCSSM.Text));

                Assert.IsTrue(matchService.Contains(_MatchNCSSM, _MatchNCSSM.Text));
                Assert.IsFalse(matchService.Contains(_NoMatchNCSSM, _NoMatchNCSSM.Text));
            }            
        }
    }
}