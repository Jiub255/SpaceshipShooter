using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public static event Action OnPlayerHurt;
    public static event Action OnPlayerDeath;

    public override void Die()
    {
        OnPlayerDeath?.Invoke();

        gameObject.SetActive(false);
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public override void GetHurt(int damage)
    {
        base.GetHurt(damage);

        OnPlayerHurt?.Invoke();
    }
}