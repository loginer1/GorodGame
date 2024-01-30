using System;
using UnityEngine;

namespace Assets.Farm
{
    public class BoxAreaView : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPointForBox = new Transform[10];
        public Transform[] GetBoxsSpawnPoints() => _spawnPointForBox;

    }
}
