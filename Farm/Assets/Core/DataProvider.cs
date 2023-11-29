using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Farm;

namespace Assets.Core
{

    public class DataProvider
    {
        private AssetProvider _assetProvider;
        private Dictionary<Type, object> _data = new Dictionary<Type, object>();

        public DataProvider(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            Init();
        }

        private void Init()
        {
            _data.Add(typeof(LandingAreaView), _assetProvider.Load("LandingArea").GetComponent<LandingAreaView>());
            _data.Add(typeof(HeroCamera), _assetProvider.Load<HeroCamera>("HeroCamera"));
            
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
