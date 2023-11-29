using UnityEngine;

namespace Assets.Farm
{
    public interface IPlanteConfig
    {
        Sprite Sprite { get; }
        string Name { get; }
        float TimeGrowing { get; }
    }
}
