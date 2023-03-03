using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Rigidbody2D _rb;

    // Set this to the enemy who dropped its speed, right after they die and activate the coin. 
    public float Speed { get; set; } = 2f; 
    private bool _headedToPlayer = false;
    private Transform _playerTransform; 

    public bool HeadedToPlayer { get { return _headedToPlayer; } set { _headedToPlayer = value; } }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_headedToPlayer)
        {
            _rb.MovePosition(Vector3.SmoothDamp(_rb.position, _playerTransform.position, ref _velocity, _smoothTime));

        }
        else
        {
            _rb.MovePosition(_rb.position + (Speed * Time.fixedDeltaTime * Vector2.down));
        }
    }

    // Starts a quick SmoothDamp to player's position. Bigger radius than the non-trigger collider. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.GetComponent<PlayerMovement>())
        {
            Debug.Log("PlayerMovement != null");

            _playerTransform = collision.GetComponent<PlayerMovement>().transform;

            // SmoothDamp to player position. 
            _headedToPlayer = true;
        }
    }
}