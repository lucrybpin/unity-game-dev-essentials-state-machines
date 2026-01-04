using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterAnimationEvents : MonoBehaviour
    {
        public event Action OnEvent1;
        public event Action OnEvent2;
        public event Action OnEvent3;
        public event Action OnEvent4;

        public void Event1()
        {
            OnEvent1?.Invoke();
        }

        public void Event2()
        {
            OnEvent2?.Invoke();
        }

        public void Event3()
        {
            OnEvent3?.Invoke();
        }

        public void Event4()
        {
            OnEvent4?.Invoke();
        }
    }
}