using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Farm
{
    public class PlacePlantePresenter : MonoBehaviour
    {
        private PlacePlanteView _placePlanteView;
        private PlacePlanteModel _placePlanteModel;
        private PlantConfigs _plantConfigs;

        public void Init(PlacePlanteModel placePlanteModel, PlantConfigs plantConfigs)
        {
            _placePlanteView = GetComponent<PlacePlanteView>();
            _placePlanteModel = placePlanteModel;
            _plantConfigs = plantConfigs;
           

        }

        public void Present()
        {
            if (_placePlanteModel.IsEmpty)
            {
                Debug.Log("pusto");
                return;
            }  
           
            var sprite = _plantConfigs.GetCofigWithType(_placePlanteModel.PlantType).Sprite;

          

            _placePlanteView.TestSetView(sprite);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _placePlanteModel.EnterTriger();
        }
    }
}
