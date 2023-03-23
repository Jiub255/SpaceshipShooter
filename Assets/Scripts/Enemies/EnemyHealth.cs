using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField]
    private List<LootInfo> _lootInfos;
/*    [SerializeField]
    private PoolTagSO _coinPoolTag;
    [SerializeField]
    private int _numberOfCoinsDropped;
    [SerializeField] 
    private float _coinSpreadRadius = 2.5f;*/

    private ObjectPool _objectPool;

    public virtual void Start()
    {
        _objectPool = S.I.ObjectPool;
    }

    public override void Die()
    {
        DropLoot();

        gameObject.SetActive(false);
    }

    private void DropLoot()
    {
        float speed = 0f;

        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            speed = GetComponent<EnemyMovement>().Speed;
        }

        foreach (LootInfo lootInfo in _lootInfos)
        {
            for (int i = 0; i < lootInfo._numberOfLootItemsDropped; i++)
            {
                GameObject loot = _objectPool.GetPooledObject(lootInfo._lootPoolTag);
                if (loot != null)
                {
                    loot.GetComponent<Coin>().Speed = speed;

                    Vector3 randomVector3 = transform.position + (Random.insideUnitSphere * lootInfo._lootSpreadRadius);
                    randomVector3.z = 0f;
                    loot.transform.position = randomVector3;

                    loot.SetActive(true);
                }
            }
        }
    }
}

[System.Serializable]
public class LootInfo
{
    public PoolTagSO _lootPoolTag;
    public int _numberOfLootItemsDropped;
    public float _lootSpreadRadius = 2.5f;
}