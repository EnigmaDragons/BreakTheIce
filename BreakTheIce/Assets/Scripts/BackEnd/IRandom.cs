using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.BackEnd
{
    public interface IRandom
    {
        int Int(int min, int max);
        void Shuffle<T>(IList<T> list);
    }

    public static class RandomExtensions
    {
        public static bool Bool(this IRandom random)
        {
            return random.Int(2) == 1;
        }

        public static int Int(this IRandom random)
        {
            return random.Int(int.MaxValue);
        }

        public static int Int(this IRandom random, int max)
        {
            return random.Int(0, max);
        }

        public static KeyValuePair<T, T2> Random<T, T2>(this IRandom random, Dictionary<T, T2> dictionary)
        {
            return dictionary.ElementAt(random.Int(dictionary.Count));
        }

        public static T Random<T>(this IRandom random, T[] array)
        {
            return array[random.Int(array.Length)];
        }

        public static T Random<T>(this IRandom random, List<T> list)
        {
            return list[random.Int(list.Count)];
        }
    }
}