using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private PoolTagSO _bulletPoolTag;
	[SerializeField]
	private float _timeBetweenShots = 0.5f;
    [SerializeField, TextArea(1,20)]
    private string _description;

    private float _timer;
    private bool _shootHeldDown = false;
    private ObjectPool _objectPool;
	private InputAction _shootAction;
    private Transform _transform;
    private int _damage;

    public string Description { get { return _description; } }
    public int Damage { get { return _damage; } }
    public float FireRate { get { return (1 / _timeBetweenShots); } }

    private void Start()
    {
        _shootAction = S.I.IM.PC.Gameplay.Shoot;
        _objectPool = S.I.ObjectPool;
        _transform = transform;

        _shootAction.started += ShootStarted;
        _shootAction.canceled += ShootEnded;
        // Could do a more powerful shot after shoot held for a little bit. 
        //_shootAction.performed += PowerShot;

        GameObject bullet = _objectPool.GetPooledObject(_bulletPoolTag);
        if (bullet != null)
        {
            _damage = bullet.GetComponent<Bullet>().Damage;
        }
    }

    private void OnDisable()
    {
        _shootAction.started -= ShootStarted;
        _shootAction.canceled -= ShootEnded;
        //_shootAction.performed -= PowerShot;
    }

    private void ShootStarted(InputAction.CallbackContext obj)
    {
        _shootHeldDown = true;
    }

    private void ShootEnded(InputAction.CallbackContext obj)
    {
        _shootHeldDown = false;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_shootHeldDown && _timer <= 0)
        {
            _timer = _timeBetweenShots;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = _objectPool.GetPooledObject(_bulletPoolTag);
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = _transform.position;
           // Debug.Log($"Bullet activated at {bullet.transform.position}");
        }
    }
}