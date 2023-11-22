using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Persons
{
    public class HeroHandler
    {
        public HeroModel _heroModel { get; private set; }
        public HeroPresenter _heroPresenter { get; private set; }
        private HeroMoving _heroMoving;

        public HeroHandler(HeroModel heroModel, float speed)
        {
            _heroModel = heroModel;
            _heroMoving = new HeroMoving(heroModel);
            _heroMoving.SetSpeed(speed);
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
