using UnityEngine;

public abstract class Health : MonoBehaviour
{
	[SerializeField]
	protected int _maxHealth = 10;
	protected int _health;

    protected virtual void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void GetHurt(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    public abstract void Die();
}