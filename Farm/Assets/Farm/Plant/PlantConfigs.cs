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

        public IPlanteConfig GetCofigWithType(PlanteType type)
        {

            var config = _planteConfigs.Find(config => config.PlanteType == type);

         
            return config;
        }
    }
}