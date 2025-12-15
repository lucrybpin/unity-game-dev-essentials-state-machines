using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] Vector2 _scrollSpeed;
    [SerializeField] Bear _bear;

    void Start()
    {
        _bear.OnMove += OnMove;
    }

    void OnMove(float speed)
    {
        if (_renderer  == null)
            return;

        if (_renderer.material == null)
            return;

        _scrollSpeed = new Vector2(0f, speed);
        Vector2 newOffset = _renderer.material.mainTextureOffset + _scrollSpeed * Time.deltaTime;
        _renderer.material.mainTextureOffset = newOffset;
    }
}
