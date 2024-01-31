using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Core
{
    public class SceneLoader
    {
        public async void LoadScnene(string nameScene, Action Callback = null)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
            operation.completed += OnSceneLoaded;
            void OnSceneLoaded(AsyncOperation async)
            {
                operation.completed -= OnSceneLoaded;
                Callback?.Invoke();
            }
        }
    }
}
