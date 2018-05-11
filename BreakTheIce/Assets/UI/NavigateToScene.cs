using System;
using UnityEngine.SceneManagement;

namespace Assets.UI
{
    public sealed class NavigateToScene : ISequenceItem
    {
        private readonly string _sceneName;

        public NavigateToScene(string sceneName)
        {
            _sceneName = sceneName;
        }

        public void Then(Action onFinish)
        {
            SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
            onFinish();
        }
    }
}
