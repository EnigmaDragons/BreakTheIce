using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.BackEnd;

namespace Assets.Scripts.BackEnd
{
    public class FakeRandom : IRandom
    {
        private Queue<int> nextResults;
        private Queue<List<int>> nextShuffles;

        public FakeRandom(List<int>[] nextShuffles, params int[] nextResults)
        {
            this.nextResults = new Queue<int>(nextResults);
            this.nextShuffles = new Queue<List<int>>(nextShuffles);
        }

        public int Int(int min, int max)
        {
            return nextResults.Dequeue();
        }

        public void Shuffle<T>(IList<T> list)
        {
            var shuffle = nextShuffles.Dequeue();
            var temp = list.ToArray();
            for (var i = 0; i < list.Count(); i++)
                list[shuffle[i]] = temp[i];
        }
    }
}