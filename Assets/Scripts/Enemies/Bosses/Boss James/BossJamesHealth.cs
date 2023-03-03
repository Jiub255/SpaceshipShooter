using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Maybe just have a generic BossHealth : Health class? 
public class BossJamesHealth : Health
{
    public static event Action OnBossKilled;

    [SerializeField]
    private IntSO _levelIndexSO;

    public override void Die()
    {
        // Disable sprite renderer. 

        // Play death effects. 

        // Show end of level menu stuff. 

        // TemporaryLoot listens, to add loot to SO's. 
        OnBossKilled?.Invoke();

        // Increase level index. 
        _levelIndexSO.Value++;

        // Load shop menu scene. 
        SceneManager.LoadScene("ShopScene");
    }
}