using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public sealed class CrossFade : ISequenceItem
    {
        private readonly Graphic _g;
        private readonly float _alpha;
        private readonly float _duration;

        public CrossFade(Graphic g, float alpha, float duration)
        {
            _g = g;
            _alpha = alpha;
            _duration = duration;
        }

        public void Then(Action onFinish)
        {
            _g.GetComponent<MonoBehaviour>()
                .StartCoroutine(Fade(onFinish));
        }

        private IEnumerator Fade(Action onFinish)
        {
            var currentColor = _g.color;
            var visibleColor = _g.color;
            visibleColor.a = _alpha;

            float counter = 0;
            while (counter < _duration)
            {
                counter += Time.deltaTime;
                _g.color = Color.Lerp(currentColor, visibleColor, counter / _duration);
                yield return null;
            }

            onFinish.Invoke();
        }
    }
}
