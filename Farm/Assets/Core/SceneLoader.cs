using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Core
{
    public class SceneLoader
    {
        public async void LoadScnene(string nameScene, Action Callback = null)
        {
            AsyncOperation oper = SceneManager.LoadSceneAsync(nameScene);
            oper.completed += OnSceneLoaded;
            void OnSceneLoaded(AsyncOperation async)
            {
                oper.completed -= OnSceneLoaded;
                Callback?.Invoke();
            }
        }
    }
}
