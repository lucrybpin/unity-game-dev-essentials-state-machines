using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Vector2 _input;

    bool _isTransitioning = false;
    float _transitionTimer = 0f;
    float _transitionTime = 0.1f;
    string _currentAnimation = "Idle";

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (_isTransitioning)
        {
            _transitionTimer += Time.deltaTime;
            if (_transitionTimer > 0.1f)
            {
                _transitionTimer = 0f;
                _isTransitioning = false;
            }
        }
        else
        {
            if (_input.y > 0 && _currentAnimation != "Walk Forward")
            {
                _animator.CrossFade("Walk Forward", _transitionTime);
                _isTransitioning = true;
                _transitionTimer = 0;
                _currentAnimation = "Walk Forward";
            }
            else if (_input.y == 0 && _currentAnimation != "Idle" && _currentAnimation != "Eat")
            {
                _animator.CrossFade("Idle", _transitionTime);
                _isTransitioning = true;
                _transitionTimer = 0;
                _currentAnimation = "Idle";
            }
            else if (_input.y < 0 && _currentAnimation != "Walk Back")
            {
                _animator.CrossFade("Walk Back", _transitionTime);
                _isTransitioning = true;
                _transitionTimer = 0;
                _currentAnimation = "Walk Back";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _animator.CrossFade("Eat", _transitionTime);
                _isTransitioning = true;
                _transitionTimer = 0;
                _currentAnimation = "Eat";
            }
        }
    }
}
