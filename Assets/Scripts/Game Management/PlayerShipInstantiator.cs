using System.Collections.Generic;
using UnityEngine;

public class PlayerShipInstantiator : MonoBehaviour
{
	[SerializeField]
	private CurrentShipSO _currentShipSO;
    [SerializeField]
    private AllWeaponsListSO _allWeaponsSO;

    //private WeaponAndGamePositions _weaponInfo;
    private List<GameObject> _ownedWeapons = new();

    private PlayerInfo _playerInfo;

    private void Awake()
    {
        _playerInfo = _currentShipSO.currentShipPrefab.GetComponent<PlayerInfo>();

        //_weaponInfo = _currentShipSO.currentShipPrefab.GetComponent<WeaponAndGamePositions>();

        float y = Camera.main.orthographicSize * -0.5f;
        Vector3 startingPosition = new Vector3(0f, y, 0f);

        GameObject shipInstance = Instantiate(_currentShipSO.currentShipPrefab, startingPosition, Quaternion.identity);

        foreach (WeaponOwned weapon in _allWeaponsSO.Weapons)
        {
            if (weapon.Owned)
            {
                _ownedWeapons.Add(weapon.WeaponPrefab);
            }
        }

        foreach (WeaponAndGamePosition weaponAndGamePosition in _playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions)
        {
            GameObject weaponInstance = Instantiate(_ownedWeapons[weaponAndGamePosition.WeaponIndex], shipInstance.transform);
            weaponInstance.transform.localPosition = weaponAndGamePosition.GamePosition;
        }

/*        foreach (WeaponAndGamePositionSO weaponPositionSO in _weaponInfo.WeaponPositions)
        {
            GameObject weaponInstance = Instantiate(_ownedWeapons[weaponPositionSO.WeaponIndex], shipInstance.transform);
            weaponInstance.transform.localPosition = weaponPositionSO.Position; 
        }*/
    }
}