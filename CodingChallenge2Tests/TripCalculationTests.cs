using CodingChallenge.Library;
using CodingChallenge2;
using System;
using Xunit;

namespace CodingChallenge2Tests
{
    public class TripCalculationTests
    {
        [Fact]
        public void BoxSupplyLargerThanSplitPilesQuota()
        {
            int exptectedPileCount = 7;
            IPileCalculationService pileCalculationService = new PileCalculationService();
            int actualPileCount = pileCalculationService.GetTripsCount("11 2 2");
            Assert.True(actualPileCount == exptectedPileCount);
        }

        [Fact]
        public void BoxSupplySmallerThanSplitPilesQuota()
        {
            int exptectedPileCount = 3;
            IPileCalculationService pileCalculationService = new PileCalculationService();
            int actualPileCount = pileCalculationService.GetTripsCount("3 2 5");
            Assert.True(actualPileCount == exptectedPileCount);
        }
    }
}
