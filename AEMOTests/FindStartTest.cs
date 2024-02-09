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
    public class FindStartTest
    {
        IServiceCollection services = new ServiceCollection();
        public FindStartTest() 
        {            
            services.AddScoped<IFindStartContract, FindStartRepository>();
        }

        [TestMethod]
        public void FindStart()
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var FindStartService = serviceProvider.GetRequiredService<IFindStartContract>();

                string Text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel _MatchCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true };
                MatchModel _NoMatchCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true };

                MatchModel _MatchNCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = true };
                MatchModel _NoMatchNCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = true };

                MatchModel _MatchCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel _NoMatchCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel _MatchNCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel _NoMatchNCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                Assert.AreEqual(FindStartService.FindStart(_MatchCSMM, _MatchCSMM.Text), 0);
                Assert.AreEqual(FindStartService.FindStart(_NoMatchCSMM, _NoMatchCSMM.Text), -1);

                Assert.AreEqual(FindStartService.FindStart(_MatchNCSMM, _MatchNCSMM.Text), 27);
                Assert.AreEqual(FindStartService.FindStart(_NoMatchNCSMM, _NoMatchNCSMM.Text), -1);

                Assert.AreEqual(FindStartService.FindStart(_MatchCSSM, _MatchCSSM.Text), 27);
                Assert.AreEqual(FindStartService.FindStart(_NoMatchCSSM, _NoMatchCSSM.Text), -1);

                Assert.AreEqual(FindStartService.FindStart(_MatchNCSSM, _MatchNCSSM.Text), 27);
                Assert.AreEqual(FindStartService.FindStart(_NoMatchNCSSM, _NoMatchNCSSM.Text), -1);
            }            
        }
    }
}