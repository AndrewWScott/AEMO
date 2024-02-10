namespace AEMOTests
{
    using AEMOContracts;
    using AEMOEntities.Models;
    using AEMORepository;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit.Sdk;

    [TestClass]
    public class FindStartTest
    {
        private readonly IServiceCollection services = new ServiceCollection();

        public FindStartTest()
        {
            this.services.AddScoped<IFindStartContract, FindStartRepository>();
        }

        [TestMethod]
        public void FindStart()
        {
            using (ServiceProvider serviceProvider = this.services.BuildServiceProvider())
            {
                var findStartService = serviceProvider.GetRequiredService<IFindStartContract>();

                string text = "Andrew Scott ANC ANSO ANNW akndo wiks";
                MatchModel matchCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = true, HasMultipleMatches = true };
                MatchModel noMatchCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = true, HasMultipleMatches = true };

                MatchModel matchNCSMM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = true };
                MatchModel noMatchNCSMM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = true };

                MatchModel matchCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                MatchModel matchNCSSM = new MatchModel { Text = text, SubText = "a", IsCaseInsensitive = false, HasMultipleMatches = false };
                MatchModel noMatchNCSSM = new MatchModel { Text = text, SubText = "z", IsCaseInsensitive = false, HasMultipleMatches = false };

                Assert.AreEqual(findStartService.FindStart(matchCSMM, matchCSMM.Text), 0);
                Assert.AreEqual(findStartService.FindStart(noMatchCSMM, noMatchCSMM.Text), -1);

                Assert.AreEqual(findStartService.FindStart(matchNCSMM, matchNCSMM.Text), 27);
                Assert.AreEqual(findStartService.FindStart(noMatchNCSMM, noMatchNCSMM.Text), -1);

                Assert.AreEqual(findStartService.FindStart(matchCSSM, matchCSSM.Text), 27);
                Assert.AreEqual(findStartService.FindStart(noMatchCSSM, noMatchCSSM.Text), -1);

                Assert.AreEqual(findStartService.FindStart(matchNCSSM, matchNCSSM.Text), 27);
                Assert.AreEqual(findStartService.FindStart(noMatchNCSSM, noMatchNCSSM.Text), -1);
            }
        }
    }
}