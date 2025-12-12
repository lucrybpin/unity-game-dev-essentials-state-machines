using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Vector2 _input;

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
}
