using UnityEngine;

public class RingBlast : MonoBehaviour
{
	[SerializeField, Range(1f, 1.2f)]
	private float _expansionSpeed = 1.08f;
	[SerializeField]
	private int _damage = 2;
    [SerializeField]
    private float _duration = 3f;

    private Transform _ringTransform;
    private CircleCollider2D _collider;
    private float _timer;

    private void Awake()
    {
        _ringTransform = transform.GetChild(0);
        _collider = GetComponent<CircleCollider2D>();
        _timer = _duration;
    }

    private void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        if (_timer <= 0f)
        {
            gameObject.SetActive(false);
        }

        _ringTransform.localScale *= _expansionSpeed/* * Time.fixedDeltaTime*/;
        _collider.radius *= _expansionSpeed/* * Time.fixedDeltaTime*/;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.GetHurt(_damage);
        }
    }
}