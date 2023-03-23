using UnityEngine;
using UnityEngine.InputSystem;

// Attach this to weapon GO.
public class RingWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _ringPrefab;
    [SerializeField]
    private float _timeBetweenShots = 3f;
    [SerializeField]
    Transform _spawnPoint;

    private float _timer;

    private void Start()
    {
        _timer = _timeBetweenShots;

        S.I.IM.PC.Gameplay.Weapon2.started += TryToMakeRing;
    }

    private void OnDisable()
    {
        S.I.IM.PC.Gameplay.Weapon2.started -= TryToMakeRing;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    private void TryToMakeRing(InputAction.CallbackContext context)
    {
        Debug.Log("Weapon2 performed");

        if (_timer < 0)
        {
            MakeRing();
            _timer = _timeBetweenShots;
        }
    }

    private void MakeRing()
    {
        Instantiate(_ringPrefab, _spawnPoint.position, Quaternion.identity);
    }
}