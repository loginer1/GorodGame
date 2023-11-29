using UnityEngine;

namespace Assets.Farm
{
    [CreateAssetMenu(fileName = "PlanteConfig")]
    public class PlanteConfig : ScriptableObject, IPlanteConfig
    {
        //     public Sprite Sprite => _sprite;
        //   public string Name => _name;
        //public float TimeGrowing => _timeGrowing;
        public Sprite Sprite { get; set; }
        public string Name  { get; set; }
        public float TimeGrowing  { get; set; }

        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _name;
        [SerializeField] private float _timeGrowing;
    }
}
