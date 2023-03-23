using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private PoolTagSO _enemyBulletPoolTag;
    [SerializeField, Range(0.33f, 3f)]
    private float _timeBetweenShots = 0.5f;
    [SerializeField]
    private Vector3 _launchDirection = Vector3.down;
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
            bullet.GetComponent<Bullet>().Direction = _launchDirection;
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }
}