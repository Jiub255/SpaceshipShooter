using System;
using UnityEngine;

public class EnemyCrash : MonoBehaviour
{
    public static event Action OnCrashedIntoPlayer;
    [SerializeField]
    private int _crashDamage = 3;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.GetHurt(_crashDamage);
            _health.Die();
        }
    }
}