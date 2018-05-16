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

        public bool Bool()
        {
            return Int(2) == 1;
        }

        public int Int()
        {
            return Int(int.MaxValue);
        }

        public int Int(int max)
        {
            return value.Next(max);
        }

        public int Int(int min, int max)
        {
            return value.Next(min, max);
        }

        public double Dbl()
        {
            return value.NextDouble();
        }

        public KeyValuePair<T, T2> Random<T, T2>(Dictionary<T, T2> dictionary)
        {
            return dictionary.ElementAt(Int(dictionary.Count));
        }

        public T Random<T>(T[] array)
        {
            return array[Int(array.Length)];
        }

        public T Random<T>(List<T> list)
        {
            return list[Int(list.Count)];
        }

        public T Between<T>(T primary, T other, double primaryWeight)
        {
            return Dbl() <= primaryWeight ? primary : other;
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