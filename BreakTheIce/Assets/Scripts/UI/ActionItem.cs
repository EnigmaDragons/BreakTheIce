using System;

namespace Assets.Scripts.UI
{
    public sealed class ActionItem : ISequenceItem
    {
        private readonly Action _action;

        public ActionItem(Action action)
        {
            _action = action;
        }

        public void Then(Action onFinish)
        {
            _action();
            onFinish();
        }
    }
}
