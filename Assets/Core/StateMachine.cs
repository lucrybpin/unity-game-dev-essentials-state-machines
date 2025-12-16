using System;
using System.Collections.Generic;

namespace StateMachines
{
    [Serializable]
    public class StateMachine
    {
        Dictionary<string, IState> _states = new Dictionary<string, IState>();

        public void AddState(string stateName, IState state)
        {
            _states[stateName] = state;
            state.StateMachine = this;
        }

        public void ChangeState(string stateName) { }

        public void Update() { }

    } // End of Class
}
