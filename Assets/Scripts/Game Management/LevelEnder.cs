using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    public static event Action OnLevelOver;

    [SerializeField, Tooltip("Wait long enough for the boss death animation to play and the coins to reach the player.")]
    private float _bossDeathDuration = 2.5f;
    [SerializeField]
    private LevelIndexSO _levelIndexSO;
    [SerializeField, Header("Canvas Info")]
    private GameObject _endOfLevelCanvas; 

    private void OnEnable()
    {
        BossHealth.OnBossKilled += OnBossKilled;
    }

    private void OnDisable()
    {
        BossHealth.OnBossKilled -= OnBossKilled;
    }

    private void OnBossKilled(Transform transform)
    {
        _levelIndexSO.Value++;

        StartCoroutine(EndLevelCo());
    }

    private IEnumerator EndLevelCo()
    {
        // Wait long enough for the boss death animation to play and the coins to reach the player. 
        yield return new WaitForSeconds(_bossDeathDuration);

        // Enable end of level canvas. 
        _endOfLevelCanvas.SetActive(true);
    }

    // Called by button on End of Level Canvas. 
    public void EndLevel()
    {
        // Disable end of level canvas. 
        _endOfLevelCanvas.SetActive(false);

        // TemporaryLoot listens, adds loot to SO's. 
        OnLevelOver?.Invoke();

        // Load shop scene. 
        SceneManager.LoadScene("ShopScene");
    }
}