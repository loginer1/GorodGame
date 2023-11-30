using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Farm
{
    public class PlacePlanteView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void TestSetView(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}
