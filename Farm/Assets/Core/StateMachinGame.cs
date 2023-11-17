using System;
using System.Collections.Generic;

namespace Assets.Core
{
    public class StateMachinGame
    {
        private Dictionary<Type, IGameState> _states = new Dictionary<Type, IGameState>();
        private IGameState _currentState;

        public void ChangeState<T>()
        {
            var type = typeof(T);
            _currentState?.Exit();

            _currentState = _states[type];
            _currentState.Enter();
        }

       public void AddState<T>(T state) where T : IGameState
       {
            if (!_states.ContainsKey(typeof(T)))
            {
                _states.Add(typeof(T), state);
            }
       }

        public void Update(float delta)
        {
            _currentState.Update(delta);
        }
    }
}