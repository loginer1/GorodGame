using UnityEngine;
using System.Collections.Generic;

namespace Assets.Farm
{
    [CreateAssetMenu(fileName = "PlanteConfig")]
    public class PlantConfigs : ScriptableObject
    {
        [SerializeField] private List<PlanteConfig> _planteConfigs;
        [SerializeField] private Sprite _defaultSprite;

        public Sprite DefaultSprite => _defaultSprite;

        public IPlanteConfig GetCofigWithType(PlanteType type)
        {
            var config = _planteConfigs.Find(config => config.PlanteType == type);
            return config;
        }
    }
}