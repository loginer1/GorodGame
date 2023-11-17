using UnityEngine;
using Assets.Core;

public class Bootstrap : MonoBehaviour
{
    private static Bootstrap instance;
    private StateMachinGame _stateMachin;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        _stateMachin = new StateMachinGame();

        var sceneLoader = new SceneLoader();
        var serializator = new Serializator();

        var assetProvider = new AssetProvider();
        var dataProvider = new DataProvider(assetProvider);

        _stateMachin.ChangeState<BootstrapState>();
    }
}
