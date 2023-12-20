using UnityEngine;
using System;

namespace Assets.Farm
{
    public interface IPlanteConfig
    {
        PlanteType PlanteType { get; }
        Sprite SpriteRostok { get; }
        Sprite Sprite { get; }
        string Name { get; }
        float TimeGrowing { get; }
    }
}
