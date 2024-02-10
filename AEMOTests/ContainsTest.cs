namespace AEMOTests
{
    using AEMOContracts;
    using AEMOEntities.Models;
    using AEMORepository;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit.Sdk;

    [TestClass]
    public class ContainsTest
    {
        private readonly IServiceCollection services = new ServiceCollection();

        public ContainsTest()
        {
            this.services.AddScoped<IContainsContract, ContainsRepository>();
        }

        [TestMethod]
        public void Contains()
        {
            using (ServiceProvider serviceProvider = this.services.BuildServiceProvider())
            {
                var containsService = serviceProvider.GetRequiredService<IContainsContract>();

                string text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel matchCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true };
                MatchModel noMatchCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true };

                MatchModel matchNCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = true };
                MatchModel noMatchNCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = true };

                MatchModel matchCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel matchNCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchNCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                Assert.IsTrue(containsService.Contains(matchCSMM, matchCSMM.Text));
                Assert.IsFalse(containsService.Contains(noMatchCSMM, noMatchCSMM.Text));

                Assert.IsTrue(containsService.Contains(matchNCSMM, matchNCSMM.Text));
                Assert.IsFalse(containsService.Contains(noMatchNCSMM, noMatchNCSMM.Text));

                Assert.IsTrue(containsService.Contains(matchCSSM, matchCSSM.Text));
                Assert.IsFalse(containsService.Contains(noMatchCSSM, noMatchCSSM.Text));

                Assert.IsTrue(containsService.Contains(matchNCSSM, matchNCSSM.Text));
                Assert.IsFalse(containsService.Contains(noMatchNCSSM, noMatchNCSSM.Text));
            }
        }
    }
}