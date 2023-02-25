using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private PoolTagSO _enemyBulletPoolTag;
    [SerializeField]
    private float _timeBetweenShots = 0.5f;
    private float _timer;
    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = S.I.ObjectPool;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _timeBetweenShots;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = _objectPool.GetPooledObject(_enemyBulletPoolTag);
        if (bullet != null)
        {
            Debug.Log("Bullet not null");

            bullet.SetActive(true);
            bullet.transform.position = transform.position;
        }
    }
}