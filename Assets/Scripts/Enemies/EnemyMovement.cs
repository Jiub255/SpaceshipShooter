using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
	private Rigidbody2D _rb;

    public float Speed { get { return _speed; } }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition((Vector2)transform.position + (_speed * Time.fixedDeltaTime * Vector2.down));
    }
}