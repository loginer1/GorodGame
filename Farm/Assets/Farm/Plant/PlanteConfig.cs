using System;
using UnityEngine;

namespace Assets.Farm
{
    [CreateAssetMenu(fileName = "PlanteConfig")]
    public class PlanteConfig : ScriptableObject, IPlanteConfig
    {
        public Sprite SpriteRostok => _spriteRostok;
        public Sprite Sprite => _sprite;
        public string Name => _name;
        public float TimeGrowing => _timeGrowing;
        public PlanteType PlanteType => _planteType;

        [SerializeField] private PlanteType _planteType;
        [SerializeField] private Sprite _spriteRostok;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _name;
        [SerializeField] private float _timeGrowing;
    }
}
