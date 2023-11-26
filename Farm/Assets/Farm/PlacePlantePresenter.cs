using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Farm
{
    public class PlacePlantePresenter : MonoBehaviour
    {
        private PlacePlanteView _placePlanteView;
        private PlacePlanteModel _placePlanteModel;

        public void Init(PlacePlanteModel placePlanteModel)
        {
            _placePlanteView = GetComponent<PlacePlanteView>();
            _placePlanteModel = placePlanteModel;
        }

        public void Present()
        {
            if (_placePlanteModel.IsEmpty)
            {
                Debug.Log("pusto");
                return;
            }
            _placePlanteView.TestSetView(_placePlanteModel.PlantType);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _placePlanteModel.EnterTriger();
        }
    }
}
