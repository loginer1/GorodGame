using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Farm {

    [RequireComponent (typeof(SpriteRenderer))]
    public class BoxPresenter : MonoBehaviour
    {
        private BoxModel _boxModel;

        public void Init(BoxModel boxModel)
        {
            _boxModel = boxModel;
        }

        public void Present(TaskTypes a, IPlaceTask placeTasks)
        {

            GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        }
    } 
}
