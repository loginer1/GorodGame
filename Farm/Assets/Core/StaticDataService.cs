using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Farm;

namespace Assets.Core
{

    public class StaticDataService
    {
        private AssetProvider _assetProvider;
        private Dictionary<Type, object> _data = new Dictionary<Type, object>();

        public StaticDataService(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            Init();
        }

        private void Init()
        {
            // _data.Add(typeof(LandingAreaView), _assetProvider.Load("LandingArea").GetComponent<LandingAreaView>());
            //       _data.Add(typeof(HeroCamera), _assetProvider.Load<HeroCamera>("HeroCamera"));
            var gameplayData = _assetProvider.LoadGameplayPrefabs();
            _data.Add(typeof(LandingAreaView), gameplayData[0].GetComponent<LandingAreaView>()) ;
            _data.Add(typeof(HeroCamera), gameplayData[1].GetComponent<HeroCamera>());
        }

        public T GetData<T>(Transform parent = null) where T : Component
        {
         
            if (_data.ContainsKey(typeof(T)))
                if (parent != null)
                    return UnityEngine.Object.Instantiate((T)_data[typeof(T)], parent);
                else
                    return UnityEngine.Object.Instantiate((T)_data[typeof(T)]);
            throw new InvalidOperationException();
        }
    }


}
