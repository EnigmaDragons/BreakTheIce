using System;

namespace Assets.Scripts.UI
{
    public sealed class Sequence
    {
        private readonly Action _execute;

        public Sequence(params ISequenceItem[] items)
        {
            Action mutableAction = () => { };
            var cnt = items.Length;
            for (var i = cnt - 1; i > -1; i--)
            {
                var stepNum = i;
                var next = mutableAction;
                mutableAction = () => items[stepNum].Then(next);
            }

            _execute = mutableAction;
        }

        public void Go()
        {
            _execute();
        }
    }
}
