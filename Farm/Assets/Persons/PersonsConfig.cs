using UnityEngine;

namespace Assets.Persons
{
    [CreateAssetMenu(fileName = "PersonsConfig")]
    public class PersonsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _heroPrefab;
        [SerializeField] private float _speed;

        public GameObject HeroPrefab => _heroPrefab;
        public float Speed => _speed;
    }
}
