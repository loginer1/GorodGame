using UnityEngine;

namespace Assets.Farm
{
    public class BoxArea
    {
        public BoxModel[] _boxModels = new BoxModel[10];

        private LandingAreaModel _landomgArea;
        private Transform[] _boxSpawnPoints;
        private int _boxCount;


        public BoxArea(BoxModel[] boxModels)
        {

          //  _boxSpawnPoints = boxAreaView.GetBoxsSpawnPoints();

            _boxModels = boxModels;
        }

        public void ActiveBox(PlanteType planteType)
        {
            _boxCount++;
            _boxModels[_boxCount - 1].SetActive(true, planteType);
            Debug.Log(_boxCount);

       //     Debug.Log(new Vector2(_boxSpawnPoints[_boxCount - 1].position.x / 4, _boxSpawnPoints[_boxCount - 1].position.y / 9.65f));
        }


       

        public void OnDisable()
        {
            _landomgArea.OnCollectBox -= ActiveBox;
        }
    }
}
