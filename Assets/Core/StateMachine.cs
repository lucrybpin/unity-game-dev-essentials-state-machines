using System.Collections.Generic;

namespace StateMachines
{
    public class StateMachine
    {
        Dictionary<string, IState> _states = new Dictionary<string, IState>();

        public void AddState(string stateName, IState state) { }

        public void ChangeState(string stateName) { }

        public void Update() { }

    } // End of Class
}
