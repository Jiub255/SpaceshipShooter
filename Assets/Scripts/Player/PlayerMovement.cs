using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f; 
	private Rigidbody2D _rb;
    private Vector2 _movement;
    private InputAction _moveAction;
    private Camera _camera;

    private float asdf;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveAction = S.I.IM.PC.Gameplay.Move;

        _camera = Camera.main;
        asdf = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    {
        _movement = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition = _camera.WorldToViewportPoint(_rb.position + (_movement * _speed * Time.fixedDeltaTime));
        nextPosition.x = Mathf.Clamp01(nextPosition.x/*, 0.05f, 0.95f*/);
        nextPosition.y = Mathf.Clamp01(nextPosition.y/*, 0.15f, 0.85f*/);
        Vector2 desiredPosition = _camera.ViewportToWorldPoint(nextPosition);

        _rb.MovePosition(desiredPosition);
    }
}