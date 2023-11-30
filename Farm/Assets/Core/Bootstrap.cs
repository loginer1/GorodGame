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

        var DI = new DiContainer();

        DI.Register(_personsConfig);
        DI.Register(_plantConfigs);

        _stateMachin.AddState(new BootstrapState(DI, _stateMachin));
        _stateMachin.AddState(new GameplayState(DI, _stateMachin));

        _stateMachin.ChangeState<BootstrapState>();
    }

    public void Update()
    {
        _stateMachin.Update(Time.deltaTime);
    }
}
