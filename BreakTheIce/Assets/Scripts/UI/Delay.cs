using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public sealed class Delay : ISequenceItem
    {
        private readonly MonoBehaviour _obj;
        private readonly float _duration;

        public Delay(MonoBehaviour obj, float duration)
        {
            _obj = obj;
            _duration = duration;
        }

        public void Then(Action onFinish)
        {
            _obj.StartCoroutine(DelayInvoke(_duration, onFinish));
        }

        private IEnumerator DelayInvoke(float waitTime, Action onFinish)
        {
            yield return new WaitForSeconds(waitTime);
            onFinish();
        }
    }
}
