using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static event Action OnCoinCollected;

    private Coin _coin;

    private void OnEnable()
    {
        _coin = GetComponentInParent<Coin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Coin collided with {collision.gameObject.name}");

        if (collision.gameObject.GetComponent<TemporaryLoot>())
        {
            CollectCoin(collision.gameObject.GetComponent<TemporaryLoot>());
        }
    }

    private void CollectCoin(TemporaryLoot temporaryLoot)
    {
        // Disable coin sprite. 

        // Play coin collected particle effects. 

        // Add one to coins. 
        temporaryLoot.Coins++;

        //Debug.Log("Collected coin.");
        
        // HUD listens for this. 
        OnCoinCollected?.Invoke();

        _coin.HeadedToPlayer = false;

        // Deactivate coin. 
        transform.parent.gameObject.SetActive(false);
    }
}