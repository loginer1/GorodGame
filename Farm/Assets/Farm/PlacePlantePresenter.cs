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

        public void Present(int statePlaceModel)
        {
            /*    if (_placePlanteModel.IsEmpty)
                {
                    Debug.Log("pusto");
                    return;
                }  
              */
            Sprite sprite;
            if (statePlaceModel == 1)
                sprite = _plantConfigs.GetCofigWithType(_placePlanteModel.PlantType).SpriteRostok;
            else// if (statePlaceModel == 2)
                sprite = _plantConfigs.GetCofigWithType(_placePlanteModel.PlantType).Sprite;

          

            _placePlanteView.TestSetView(sprite);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _placePlanteModel.EnterTriger();
        }
    }
}
