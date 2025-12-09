using UnityEngine;

[RequireComponent(typeof(ChestView))]
public class ChestController : MonoBehaviour
{
    [SerializeField] ChestView _view;

    void Awake()
    {
        _view = GetComponent<ChestView>();
    }

    void Start()
    {
        _view.OnClick += OnClick;
    }

    void OnClick()
    {
        Debug.Log("Clicked");
    }
}
