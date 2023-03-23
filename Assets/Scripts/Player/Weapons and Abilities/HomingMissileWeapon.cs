using UnityEngine;
using UnityEngine.InputSystem;

public class HomingMissileWeapon : MonoBehaviour
{
	[SerializeField]
	private Transform _spawnPoint;
    [SerializeField]
    private LayerMask _enemyLayerMask;
    [SerializeField]
    private GameObject _homingMissilePrefab;
    [SerializeField]
    private float _timeBetweenShots = 2f;
    private float _timer;

	private float _radius = 1f;

    private void Start()
    {
        _timer = _timeBetweenShots;

		S.I.IM.PC.Gameplay.Weapon2.started += TryShootMissile;
    }

    private void OnDisable()
    {
        S.I.IM.PC.Gameplay.Weapon2.started -= TryShootMissile;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    private void TryShootMissile(InputAction.CallbackContext context)
    {
        if (_timer < 0f)
        {
            _timer = _timeBetweenShots;

        	// Do increasing size overlap circles until you get hits, then find the closest one and make it the target. 
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_spawnPoint.position, _radius, _enemyLayerMask, -0.1f, 0.1f);

            for (int i = 2; i < 10; i++)
            {
                colliders = Physics2D.OverlapCircleAll(_spawnPoint.position, _radius * i, _enemyLayerMask, -0.1f, 0.1f);
                if (colliders.Length > 0)
                {
                    Transform closestEnemy = colliders[0].transform;
                    foreach (var collider in colliders)
                    {
                        if (Vector3.Distance(_spawnPoint.position, collider.transform.position) < Vector3.Distance(_spawnPoint.position, closestEnemy.position))
                        {
                            closestEnemy = collider.transform;
                        }
                    }
                    ShootMissile(closestEnemy);
                    return;
                }
            }
        }
    }

    private void ShootMissile(Transform target)
    {
        GameObject missile = Instantiate(_homingMissilePrefab, _spawnPoint.position, Quaternion.identity);
        missile.GetComponent<HomingMissile>().Target = target;
    }
}