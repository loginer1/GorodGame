using UnityEngine;
using System.Collections.Generic;
using Assets.Farm;

public class LandingAreaView : MonoBehaviour
{
    public List<PlacePlantePresenter> PlacePlantePresenters = new List<PlacePlantePresenter>();

    public int GetPlaceCount() => PlacePlantePresenters.Count;

}
