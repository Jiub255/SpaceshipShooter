using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int _damage = 1;
    [SerializeField]
    protected float _speed = 50f;
    [SerializeField]
    protected ParticleSystem _impactParticleEffect;
    // Projectile shouldn't hold the direction. Let the weapon or character decide. Probably weapon. 
    public Vector2 Direction = Vector2.up;
    protected Rigidbody2D _rb;

    public int Damage { get { return _damage; } }

    protected virtual void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();

        Launch();
    }

    protected virtual void Launch()
    {
        _rb.AddForce(_speed * Direction, ForceMode2D.Impulse);
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
    protected abstract void OnDisable();
}