namespace AEMOTests
{
    using AEMOContracts;
    using AEMOEntities;
    using AEMOEntities.Models;
    using AEMORepository;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Xunit.Sdk;

    [TestClass]
    public class MatchTest
    {
        private readonly IServiceCollection services = new ServiceCollection();

        public MatchTest()
        {
            this.services.AddScoped<IMatchContract, MatchRepository>();
            this.services.AddScoped<IContainsContract, ContainsRepository>();
            this.services.AddScoped<IFindStartContract, FindStartRepository>();
        }

        [Fact]
        [TestMethod]
        public void Match()
        {
            using (ServiceProvider serviceProvider = this.services.BuildServiceProvider())
            {
                var matchService = serviceProvider.GetRequiredService<IMatchContract>();

                string text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel matchCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true };
                MatchModel noMatchCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true };

                MatchModel matchNCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = true };
                MatchModel noMatchNCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = true };

                MatchModel matchCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel matchNCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchNCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                matchService.Match(matchNCSMM).Should().BeEquivalentTo(new MatchTextModel
                {
                    Match = true,
                    StartOfSubtext = new List<int>() { 28 },
                });

                matchService.Match(noMatchNCSSM).Should().BeEquivalentTo(new MatchTextModel
                {
                    Match = false,
                    StartOfSubtext = new List<int>(),
                });

                // todo: add more tests
            }
        }
    }
}