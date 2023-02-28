using UnityEngine;

public abstract class Health : MonoBehaviour
{
	[SerializeField]
	protected int _maxHealth = 10;
	protected int _currentHealth;

    public int MaxHealth { get { return _maxHealth; } }
    public int CurrentHealth { get { return _currentHealth;} }

    protected virtual void Awake()
    {
        if (GetComponent<ShipInfo>() != null)
        {
            _maxHealth = GetComponent<ShipInfo>().MaxHealth;
        }
        _currentHealth = _maxHealth;
    }

    public virtual void GetHurt(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    public abstract void Die();
}