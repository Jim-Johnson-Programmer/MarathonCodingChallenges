using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Library
{

    /// <summary>
    /// Calculates the number of box piles
    /// </summary>
    public class PileCalculationService : IPileCalculationService
    {
        int _originalBoxPileSize = 0;
        int _maxPileSize = 0;
        int _splitPileQuota = 0;
        List<int> _pilesCollection;

        /// <summary>
        /// Main entry point.  Takes input string that has three integers, processes them for box pile rules.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Pile/Trips Count expected</returns>
        public int GetTripsCount(string inputString)
        {
            int tripCount = 0;
            int firstPilesCount = 0;
            int secondPilesCount = 0;
            int pileSize = GetPileSize(inputString);
            LoadPiles(pileSize);
            _pilesCollection.RemoveAll(t => t == 0);
            tripCount = _pilesCollection.Where(t => t != 0).Count();

            return tripCount;
        }

        /// <summary>
        /// Loads piles collection and makes 
        /// </summary>
        /// <param name="pileSize"></param>
        private void LoadPiles(int pileSize)
        {
            int remainingBoxesCount = _originalBoxPileSize;
            int firstCountOffSet = 0;

            if (pileSize == 1)
            {
                GetRemainderPilesCount(pileSize, ref remainingBoxesCount);
                return;
            }

            int firstPileSizeCount = GetPilesCountForPilesSize(pileSize, firstCountOffSet, ref remainingBoxesCount);
            int secondPileSizeCount = GetRemainderPilesCount(pileSize - 1, ref remainingBoxesCount);
            while (firstPileSizeCount - secondPileSizeCount != 1)
            {
                _pilesCollection.Clear();
                remainingBoxesCount = _originalBoxPileSize;
                ++firstCountOffSet;
                firstPileSizeCount = GetPilesCountForPilesSize(pileSize, firstCountOffSet, ref remainingBoxesCount);
                secondPileSizeCount = GetRemainderPilesCount(pileSize - 1, ref remainingBoxesCount);
            }
        }

        /// <summary>
        /// Function for taking primary counts
        /// </summary>
        /// <param name="pileSize"></param>
        /// <param name="offSet"></param>
        /// <param name="boxesCount"></param>
        /// <returns></returns>
        private int GetPilesCountForPilesSize(int pileSize, int offSet, ref int boxesCount)
        {
            int pilesCount = 0;
            do
            {
                _pilesCollection.Add(pileSize);
                boxesCount -= pileSize;
                pilesCount++;
            } while ((boxesCount - offSet) > pileSize);
            return pilesCount;
        }

        /// <summary>
        /// Function for secondary and single box stacks
        /// </summary>
        /// <param name="pileSize"></param>
        /// <param name="boxesCount"></param>
        /// <returns></returns>
        private int GetRemainderPilesCount(int pileSize, ref int boxesCount)
        {
            int pilesCount = 0;
            while (boxesCount > 0)
            {
                _pilesCollection.Add(pileSize);
                boxesCount -= pileSize;
                pilesCount++;
            };
            return pilesCount;
        }

        /// <summary>
        /// Gets expected size of pile
        /// </summary>
        /// <param name="inputArgs"></param>
        /// <returns></returns>
        private int GetPileSize(string inputArgs)
        {
            string[] argsArray = inputArgs.Split(" ");
            _originalBoxPileSize = int.Parse(argsArray[0]);
            _maxPileSize = int.Parse(argsArray[1]);
            _splitPileQuota = int.Parse(argsArray[2]);
            _pilesCollection = new List<int>(_splitPileQuota);
            int workingPileSize = _originalBoxPileSize;

            if (_splitPileQuota >= _originalBoxPileSize) return 1;

            if (workingPileSize > _maxPileSize)
            {
                int firstNumSplit = 0;
                int secondNumSplit = 0;
                do
                {
                    if (workingPileSize % 2 == 0)
                    {
                        firstNumSplit = (workingPileSize / 2);
                        secondNumSplit = firstNumSplit;
                    }
                    else
                    {
                        secondNumSplit = (workingPileSize / 2);
                        firstNumSplit = workingPileSize - secondNumSplit;
                    }

                    if (firstNumSplit > secondNumSplit && firstNumSplit >= _maxPileSize)
                    {
                        workingPileSize = firstNumSplit;
                    }
                    else
                    {
                        workingPileSize = secondNumSplit;
                    }
                } while (workingPileSize > _maxPileSize);
            }
            return workingPileSize;
        }
    }
}
