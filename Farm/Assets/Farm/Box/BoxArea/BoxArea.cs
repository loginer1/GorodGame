using UnityEngine;

namespace Assets.Farm
{
    public class BoxArea
    {
        public BoxModel[] _boxModels = new BoxModel[10];

        private LandingAreaModel _landomgArea;
        private int _boxCount;

        public BoxArea(BoxModel[] boxModels)
        {
            _boxModels = boxModels;
        }

        public void ActiveBox(PlanteType planteType)
        {
            _boxCount++;
            _boxModels[_boxCount - 1].SetActive(true, planteType);
        }

        public void OnDisable()
        {
            _landomgArea.OnCollectBox -= ActiveBox;
        }
    }
}
