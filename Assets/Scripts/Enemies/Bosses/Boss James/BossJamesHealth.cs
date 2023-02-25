using System;

// Maybe just have a generic BossHealth : Health class? 
public class BossJamesHealth : Health
{
    public static event Action OnBossKilled;

    public override void Die()
    {
        // Disable sprite renderer. 

        // Play death effects. 

        // Show end of level menu stuff. 

        // TemporaryLoot listens, to add loot to SO's. 
        OnBossKilled?.Invoke();

        // Load shop menu scene. 
    }
}