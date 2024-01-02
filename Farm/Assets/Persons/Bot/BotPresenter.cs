using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Persons
{
    public class BotPresenter : MonoBehaviour
    {
        private BotModel _botModel;

        public void Init(BotModel botModel)
        {
            _botModel = botModel;
            _botModel.ChangePosition += PresentPosition;
        }

        public void PresentPosition()
        {
            transform.position = _botModel._position;
        }

        private void OnDestroy()
        {
            _botModel.ChangePosition -= PresentPosition;
        }
    }
}
