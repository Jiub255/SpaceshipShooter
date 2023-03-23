using System;
using UnityEngine;

// Maybe just have a generic BossHealth : EnemyHealth class, 
// and extend it for certain bosses if you want extra functionality. 
public class BossHealth : EnemyHealth
{
    public static event Action<Transform> OnBossKilled;

    // Just for passing to the coins for now. Probably use it later for targeting etc. 
    private Transform _playerTransform; 

    public override void Start()
    {
        base.Start();
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    public override void Die()
    {
        base.Die();

        // Disable sprite renderer. 

        // Play death effects. 
  
        // Coin listens, sets _playerTransform and sets _headedToPlayer to true. LevelEnder listens, calls EndLevel(). 
        OnBossKilled?.Invoke(_playerTransform);
    }
}