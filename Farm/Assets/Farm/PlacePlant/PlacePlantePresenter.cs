using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Persons;

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

        public void PresentSprite(int statePlaceModel)
        {
            Sprite sprite;
            if (statePlaceModel == 1)
            {
                sprite = _plantConfigs.GetCofigWithType(_placePlanteModel.PlantType).SpriteRostok;
                ActivateSlider(true);
            }
            else if (statePlaceModel == 2)
            {
                sprite = _plantConfigs.GetCofigWithType(_placePlanteModel.PlantType).Sprite;
                ActivateSlider(false);
            }
            else
                sprite = _plantConfigs.DefaultSprite;

            _placePlanteView.TestSetView(sprite);
        }

        public void PresentSlider(float value)
        {
            _placePlanteView.SetSliderValue(value);
        }

        public void ActivateSlider(bool isActivate)
        {
            _placePlanteView.SetActiveSlider(isActivate);
        }

        private void Update()
        {
            float timeLeft = _placePlanteModel.TimeLeftGrowing;
            if (timeLeft > 0) 
                PresentSlider(timeLeft);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            HeroModel heroModel;
            if(collision.gameObject.TryGetComponent(out HeroPresenter heroPresenter))
            {
                heroModel = heroPresenter._heroModel;
                _placePlanteModel.EnterTriger(heroModel);//TEMPP
                _placePlanteView.ShadowPlace(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _placePlanteView.ShadowPlace(false);
            _placePlanteModel.ExitTriger();
        }
    }
}
