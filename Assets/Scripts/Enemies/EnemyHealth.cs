using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField]
    private PoolTagSO _coinPoolTag;
    [SerializeField]
    private int _numberOfCoinsDropped;
    [SerializeField] 
    private float coinSpreadRadius = 0.2f;

    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = S.I.ObjectPool;
    }

    public override void Die()
    {
        float speed = GetComponent<EnemyMovement>().Speed;
        for (int i = 0; i < _numberOfCoinsDropped; i++)
        {
            GameObject coin = _objectPool.GetPooledObject(_coinPoolTag);
            if (coin != null)
            {
                coin.GetComponent<Coin>().Speed = speed;
                // Will putting non-trigger colliders on each coin make them spread out? 
                // Make better spread. This is a regular square.
                // Make a circle, with more the closer you get to the center. 
                float randX = Random.Range(-coinSpreadRadius, coinSpreadRadius);
                float randY = Random.Range(-coinSpreadRadius, coinSpreadRadius);
                coin.transform.position = new Vector3(transform.position.x + randX, transform.position.y + randY, 0f);
                coin.transform.rotation = transform.rotation;
                coin.SetActive(true);
            }
        }

        gameObject.SetActive(false);
    }
}