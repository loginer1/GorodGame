using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Assets.Farm
{
    [CreateAssetMenu(fileName = "PlanteConfig")]
    public class PlantConfigs : ScriptableObject
    {
        [SerializeField] private List<PlanteConfig> _planteConfigs;

        public IPlanteConfig GetCofigWithType(Type type)
        {

            Debug.Log(_planteConfigs[0].Name);
            var config = _planteConfigs.Find(config => config.Type == type);

            foreach (var a in _planteConfigs)
                Debug.Log(a.Name);

            return config;
        }
    }
}