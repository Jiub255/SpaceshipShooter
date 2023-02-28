using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float _speed; 
	private Rigidbody2D _rb;
    private Vector2 _movement;
    private InputAction _moveAction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveAction = S.I.IM.PC.Gameplay.Move;
        _speed = GetComponent<ShipInfo>().Speed;
    }

    private void Update()
    {
        _movement = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 desiredPosition = _rb.position + (_movement * _speed * Time.fixedDeltaTime);

        _rb.MovePosition(desiredPosition);
    }
}