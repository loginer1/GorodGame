using UnityEngine;
using System.Collections.Generic;

namespace Assets.Core
{
    public class AssetProvider
    {
        private KeysConfig _keysConfig;

        private Dictionary<string, GameObject> _gameplayData = new Dictionary<string, GameObject>();

        public GameObject[] LoadGameplayPrefabs() 
        {
            string path = "Prefabs/";

            List<GameObject> data = new List<GameObject>();

            if (_keysConfig == null)
                _keysConfig = GetKeysConfig();

            foreach (var key in _keysConfig.GamplayKeys)
            {
                var prefab = Resources.Load<GameObject>(path + key);
                data.Add(prefab);
                _gameplayData.Add(key, prefab);
            }

            if (data == null)
            {
                Debug.LogError("чогось не загрузилося вать недобрий ключ вать путь");
                return null;
            }

            return data.ToArray();
        }

        private KeysConfig GetKeysConfig()
        {
            var config = Resources.Load<KeysConfig>("Configs/KeysConfig");
            _keysConfig = config;
            return config;
        }

        public GameObject Load(string name)
        {
            string path = "Prefabs/" + name;

            var data = Resources.Load(path) as GameObject;
            if (data == null)
            {
                Debug.LogError("префаба нема вать такого компонента нема на сьому gameobject");
                return null;
            }
            return data;
        }
    }
}
