using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    private Coin _coin;

    private void OnEnable()
    {
        _coin = GetComponentInParent<Coin>();
    }

    // Starts a quick SmoothDamp to player's position. Bigger radius than the coin collector trigger collider. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log($"Coin collided with {collision.gameObject.name}");

        if (collision.GetComponent<PlayerMovement>())
        {
            _coin.PlayerTransform = collision.GetComponent<PlayerMovement>().transform;

            _coin.HeadedToPlayer = true;
        }
    }
}