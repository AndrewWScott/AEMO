using AEMO.Controllers;
using AEMOContracts;
using AEMOEntities;
using AEMOEntities.Models;
using AEMORepository;
using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using Xunit.Sdk;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AEMOTests
{
    [TestClass]
    public class MatchRTest
    {
        IServiceCollection services = new ServiceCollection();
        public MatchRTest() 
        {            
            services.AddScoped<IMatchRContract, MatchR>();
            services.AddScoped<IMatchContract, MatchRepository>();
            services.AddScoped<IFindStartContract, FindStartRepository>();
        }

        [Fact]
        [TestMethod]
        public void Match()
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var matchService = serviceProvider.GetRequiredService<IMatchRContract>();

                string Text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel _MatchCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true, MatchingText = Text };
                MatchModel _NoMatchCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true, MatchingText = Text };

                MatchModel _MatchNCSMM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = true, MatchingText = Text };
                MatchModel _NoMatchNCSMM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = true, MatchingText = Text };

                MatchModel _MatchCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = false, MatchingText = Text };
                MatchModel _NoMatchCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = false, MatchingText = Text };

                MatchModel _MatchNCSSM = new MatchModel { Text = Text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false, MatchingText = Text };
                MatchModel _NoMatchNCSSM = new MatchModel { Text = Text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false, MatchingText = Text };

                matchService.MatchRecursivly(_MatchNCSMM, new MatchTextModel
                {
                    StartOfSubtext = new List<int>(),
                }).Should().BeEquivalentTo(new MatchTextModel
                {
                    Match = true,
                    StartOfSubtext = new List<int>() { 28 },
                });

                matchService.MatchRecursivly(_NoMatchNCSSM, new MatchTextModel
                {
                    StartOfSubtext = new List<int>(),
                }).Should().BeEquivalentTo(new MatchTextModel
                {
                    Match = false,
                    StartOfSubtext = new List<int>(),
                });
            }            
        }
    }
}