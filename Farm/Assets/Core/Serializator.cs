using System.IO;
using UnityEngine;

namespace Assets.Core
{
    public class Serializator
    {
        public void SaveData<T>(T data, string fileName)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(Application.persistentDataPath, fileName);

            File.WriteAllText(path, json);
        }

        public T LoadData<T>(string filename)
        {
            string path = Path.Combine(Application.persistentDataPath, filename);
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path); ;
                var data = JsonUtility.FromJson<T>(jsonData);
                return data;
            }
            else
            {
                Debug.Log("nema Path");
                return default(T);
            }
        }
    }
}
