using UnityEngine;
using System;

namespace Assets.Farm
{
    public interface IPlanteConfig
    {
        Type Type { get; }
        Sprite Sprite { get; }
        string Name { get; }
        float TimeGrowing { get; }
    }
}
