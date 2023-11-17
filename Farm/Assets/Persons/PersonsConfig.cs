using UnityEngine;

namespace Assets.Persons
{
    [CreateAssetMenu(fileName = "PersonsConfig")]
    public class PersonsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _heroPrefab;

        public GameObject HeroPrefab => _heroPrefab;
    }
}
