using UnityEngine;

namespace Assets.Core
{
    public class AssetProvider
    {
        public T Load<T>(string name) where T : Component
        {
            string path = "Prefabs/" + name;

            T data = Resources.Load<T>(path);

            if (data == null)
            {
                Debug.LogError("префаба нема вать такого компонента нема на сьому gameobject");
                return default(T);
            }

            return data;
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
