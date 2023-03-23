using UnityEngine;

public class HomingMissile : MonoBehaviour
{
	public Transform Target { get; set; }

    [SerializeField]
    private float _smoothTime = 0.3f;
    [SerializeField]
    private int _damage = 5;

	private Rigidbody2D _rb;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            _rb.MovePosition(Vector3.SmoothDamp(_rb.position, Target.position, ref _velocity, _smoothTime));

            // Like Transform.LookAt but in 2D. 
            transform.up = Target.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            Debug.Log("Missile hit enemy.");
            enemyHealth.GetHurt(_damage);
        }
        gameObject.SetActive(false);
    }
}