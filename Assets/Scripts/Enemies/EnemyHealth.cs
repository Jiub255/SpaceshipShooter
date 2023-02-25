using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField]
    private PoolTagSO _coinPoolTag;
    [SerializeField]
    private int _numberOfCoinsDropped;
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
                coin.SetActive(true);
            }
        }

        gameObject.SetActive(false);
    }
}