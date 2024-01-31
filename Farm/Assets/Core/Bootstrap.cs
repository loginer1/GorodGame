using UnityEngine;
using Assets.Persons;
using Assets.Core;
using Assets.Farm;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PersonsConfig _personsConfig;
    [SerializeField] private PlantConfigs _plantConfigs;

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

        var serviceLocator = new ServiceLocator();

        serviceLocator.Register(_personsConfig);
        serviceLocator.Register(_plantConfigs);

        _stateMachin.AddState(new BootstrapState(serviceLocator, _stateMachin));
        _stateMachin.AddState(new GameplayState(serviceLocator, _stateMachin));

        _stateMachin.ChangeState<BootstrapState>();
    }

    public void Update()
    {
        _stateMachin.Update(Time.deltaTime);
    }
}
