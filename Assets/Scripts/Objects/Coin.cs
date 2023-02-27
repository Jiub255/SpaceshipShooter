using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected; 

   // [SerializeField]
    //private float _coinCollectRadius = 0.5f; 
    [SerializeField]
    private float _smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Rigidbody2D _rb;
    // Set this to the enemy who dropped it's speed, right after they die and activate the coin. 
    public float Speed { get; set; } = 2f; 
    private bool _headedToPlayer = false;
    private Transform _playerTransform; 

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        // Enable coin sprite. 
    }

    private void FixedUpdate()
    {
        if (_headedToPlayer)
        {
            //if (Vector3.Distance(_rb.position, _playerTransform.position) > _coinCollectRadius)
           // {
                _rb.MovePosition(Vector3.SmoothDamp(_rb.position, _playerTransform.position, ref _velocity, _smoothTime));
           // }
/*            else
            {
                _rb.MovePosition(_playerTransform.position);

                CollectCoin(_playerTransform);
            }*/
        }
        else
        {
            _rb.MovePosition(_rb.position + (Speed * Time.fixedDeltaTime * Vector2.down));
        }
    }

    // Starts a quick SmoothDamp to player's position. Bigger radius than the non-trigger collider. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.GetComponent<PlayerMovement>())
        {
            Debug.Log("PlayerMovement != null");

            _playerTransform = collision.GetComponent<PlayerMovement>().transform;
            // SmoothDamp to player position. 
            _headedToPlayer = true;
           //StartCoroutine(SmoothDampToPlayer(playerTransform));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            CollectCoin(_playerTransform);
        }
    }

    private void CollectCoin(Transform player)
    {
        TemporaryLoot temporaryLoot = player.gameObject.GetComponentInChildren<TemporaryLoot>();

        // Disable coin sprite. 

        // Play coin collected particle effects. 

        // Add one to coins. 
        temporaryLoot.Coins++;

        Debug.Log("Collected coin.");
        // HUD listens for this. 
        OnCoinCollected?.Invoke();

        _headedToPlayer = false;

        // Deactivate coin. 
        gameObject.SetActive(false);
    }
}