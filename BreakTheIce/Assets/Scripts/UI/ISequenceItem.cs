using System;

namespace Assets.Scripts.UI
{
    public interface ISequenceItem
    {
        void Then(Action onFinish);
    }
}
