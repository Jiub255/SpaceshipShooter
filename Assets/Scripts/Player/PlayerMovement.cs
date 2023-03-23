using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D _rb;
    private float _topSpeed; 
    private InputAction _moveAction;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private float _timeToTopSpeed;

    private void Start()
    {
        ShipInfo shipInfo = GetComponent<ShipInfo>();
        _rb = GetComponent<Rigidbody2D>();
        _topSpeed = shipInfo.TopSpeed;
        _timeToTopSpeed = shipInfo.TimeToTopSpeed;
        _moveAction = S.I.IM.PC.Gameplay.Move;
    }

    private void Update()
    {
        _movementInput = _moveAction.ReadValue<Vector2>();
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            _timeToTopSpeed);
    }

    private void FixedUpdate()
    {
        Vector2 desiredPosition = _rb.position + (_smoothedMovementInput * _topSpeed * Time.fixedDeltaTime);

        _rb.MovePosition(desiredPosition);
    }
}