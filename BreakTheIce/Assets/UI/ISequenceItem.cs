using System;

namespace Assets.UI
{
    public interface ISequenceItem
    {
        void Then(Action onFinish);
    }
}
