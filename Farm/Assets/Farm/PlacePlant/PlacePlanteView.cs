using UnityEngine;
using UnityEngine.UI;

namespace Assets.Farm
{
    public class PlacePlanteView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void TestSetView(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void ShadowPlace(bool active)
        {
            if (active)
                _spriteRenderer.color = new Color(.7f, .7f, .7f);//TEMP
            else
                _spriteRenderer.color = new Color(1, 1, 1);
        }

        public void SetSliderValue(float value)
        {
            _slider.value = value;
        }

        public void SetActiveSlider(bool isActive)
        {
            _slider.gameObject.SetActive(isActive);
        } 
    }
}
