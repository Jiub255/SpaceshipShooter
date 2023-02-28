using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField]
    private WeaponsSO _weaponsSO;

    private int _weaponIndex;
    private WeaponPositions _weapons;
    private int _slotIndex;
    private OutfitShipUI _outfitShipUI;

    public void SetupSlot(OutfitShipUI outfitShipUI)
    {
        _outfitShipUI = outfitShipUI;
    }

    public void NextSlot()
    {
        _slotIndex++;
        if (_slotIndex >= _weapons.GameAndMenuPositions.Count)
        {
            _slotIndex = 0;
        }
        // Deactivate all slots. 

        // Activate current index slot. 
    }

    public void PreviousSlot()
    {
        _slotIndex--;
        if (_slotIndex < 0)
        {
            _slotIndex = _weapons.GameAndMenuPositions.Count - 1;
        }
        // Deactivate all slots. 

        // Activate current index slot. 
    }

    public void NextWeapon()
    {
        _weaponIndex++;
        if (_weaponIndex >= _weaponsSO.Weapons.Count)
        {
            _weaponIndex = 0;
        }
        // Displays weapon in the little selector on the left and the big display on the right. 
        DisplayWeapon();
        _outfitShipUI.DisplayWeapon();
    }

    public void PreviousWeapon()
    {
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _weaponsSO.Weapons.Count - 1;
        }
        DisplayWeapon();
        _outfitShipUI.DisplayWeapon();
    }

    private void DisplayWeapon()
    {
        throw new NotImplementedException();
    }
}