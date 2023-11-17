using System;

namespace Assets.Core
{
    public class BootstrapState : IGameState
    {   
        private Serializator _serializator;
        private SceneLoader _sceneLoader;
        private StateMachinGame _stateMachin;

        public BootstrapState(StateMachinGame stateMachin,Serializator serializator, SceneLoader sceneLoader)
        {
            _stateMachin = stateMachin; 
            _serializator = serializator;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
      
            _sceneLoader.LoadScnene("GameplayScene", () => _stateMachin.ChangeState<GameplayState>());
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {
        }
    }

}
