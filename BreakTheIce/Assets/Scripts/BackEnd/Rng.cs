using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.BackEnd
{
    public class Rng : IRandom
    {
        private readonly Random value;

        public Rng(Random random)
        {
            value = random;
        }

        public int Int(int min, int max)
        {
            return value.Next(min, max);
        }

        public void Shuffle<T>(IList<T> list)
        {
            for (var n = list.Count - 1; n > 1; n--)
            {
                var k = this.value.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}