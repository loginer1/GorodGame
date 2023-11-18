using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Persons
{
    public class HeroHandler
    {
        private HeroModel _heroModel;
        private HeroPresenter _heroPresenter;
        private HeroMoving _heroMoving; 

        public HeroHandler(HeroModel heroModel)
        {
            _heroModel = heroModel;
            _heroMoving = new HeroMoving(heroModel);

        }

        public void Tick(float delta)
        {
            _heroMoving.Tick(delta);
        }


        public void SetPresenter(HeroPresenter heroPresenter)
        {
            _heroPresenter = heroPresenter;
            _heroPresenter.Init(_heroModel);
            Init();
        }

        private void Init()
        {
            _heroModel.ChangePosition += _heroPresenter.PresentPosition;
        }


    }
}
