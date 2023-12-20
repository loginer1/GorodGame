using UnityEngine;

[CreateAssetMenu(fileName = "keysConfig")]
public class KeysConfig: ScriptableObject 
{
    [SerializeField] private string[] _gameplayKeys;

    public string[] GamplayKeys => _gameplayKeys;
}

