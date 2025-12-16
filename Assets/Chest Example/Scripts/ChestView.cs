using System;
using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ChestView : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        public event Action OnClick;

        void OnMouseDown()
        {
            OnClick?.Invoke();
        }

        public void Open()
        {
            _animator.SetTrigger("Open");
        }

        public void Close()
        {
            _animator.SetTrigger("Close");
        }

    } // End of Class
}