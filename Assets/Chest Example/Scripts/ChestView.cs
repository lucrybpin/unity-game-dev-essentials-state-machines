using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ChestView : MonoBehaviour
{
    public event Action OnClick;

    void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
