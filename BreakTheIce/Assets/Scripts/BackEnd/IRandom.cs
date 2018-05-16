using System.Collections.Generic;

namespace Assets.Scripts.BackEnd
{
    public interface IRandom
    {
        int Int();
        int Int(int max);
        int Int(int min, int max);
        void Shuffle<T>(IList<T> list);
    }
}