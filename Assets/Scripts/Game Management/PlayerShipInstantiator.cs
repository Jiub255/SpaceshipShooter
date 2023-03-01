using System.Collections.Generic;
using UnityEngine;

public class PlayerShipInstantiator : MonoBehaviour
{
	[SerializeField]
	private CurrentShipSO _currentShipSO;
    [SerializeField]
    private AllWeaponsListSO _allWeaponsSO;

    private WeaponAndGamePositions _weaponInfo;
    private List<GameObject> _ownedWeapons = new();

    private void Awake()
    {
        _weaponInfo = _currentShipSO.currentShipPrefab.GetComponent<WeaponAndGamePositions>();

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

        foreach (WeaponAndGamePositionSO weaponPositionSO in _weaponInfo.WeaponPositions)
        {
            GameObject weaponInstance = Instantiate(_ownedWeapons[weaponPositionSO.WeaponIndex], shipInstance.transform);
            weaponInstance.transform.localPosition = weaponPositionSO.Position; 
            // Is this using the same index as the owned weapons list? YES FIX
            //GameObject weaponInstance = Instantiate(_allWeaponsSO.Weapons[weaponPositionSO.WeaponIndex].WeaponPrefab, shipInstance.transform);
        }
    }
}