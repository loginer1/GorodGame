using UnityEngine;
using Assets.Persons;
using Assets.Core;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PersonsConfig _personsConfig;

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


        _stateMachin.AddState(new BootstrapState(_stateMachin, serializator, sceneLoader));
        _stateMachin.AddState(new GameplayState(_personsConfig));

        _stateMachin.ChangeState<BootstrapState>();


    }
}
