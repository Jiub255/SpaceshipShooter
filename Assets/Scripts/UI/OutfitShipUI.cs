using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutfitShipUI : MonoBehaviour
{
    [SerializeField, Header("Data")]
    private CurrentShipSO _currentShipSO;
    [SerializeField]
    private GameplayStatisticsSO _gameplayStatisticsSO;
    [SerializeField]
    private WeaponsSO _weaponsSO;

    [SerializeField, Header("Right Side Weapon Display")]
    private Image _weaponImage;
    [SerializeField]
    private TextMeshProUGUI _weaponName;
    [SerializeField]
    private TextMeshProUGUI _weaponDescription;
    [SerializeField]
    private TextMeshProUGUI _damage;
    [SerializeField]
    private TextMeshProUGUI _fireRate;

    [SerializeField, Header("Left Side Ship Display")]
    private Image _shipImage;
    [SerializeField]
    private GameObject _weaponSlotPrefab;

    private int _weaponIndex;
    private WeaponPositions _weapons;
    private int _slotIndex;
    private List<WeaponSlot> _weaponSlots;
    private List<GameObject> _ownedWeapons;

    private void OnEnable()
    {
        _weapons = _currentShipSO.currentShipPrefab.GetComponentInChildren<WeaponPositions>();

        foreach (WeaponOwned weapon in _weaponsSO.Weapons)
        {
            if (weapon.Owned)
            {
                _ownedWeapons.Add(weapon.WeaponPrefab);
            }
        }

        InitializeMenu();
        DisplayWeapon();
    }

    private void InitializeMenu()
    {
        _shipImage.sprite = _currentShipSO.currentShipPrefab.GetComponent<SpriteRenderer>().sprite;
        
        // TODO: Instantiate ship menu prefab instead, with GO children at the weapon slot positions. 

        // Instantiate weapon slots at menu positions. 
/*        foreach (GameAndMenuPosition gameAndMenuPosition in _weapons.GameAndMenuPositions)
        {
            // Will this instantiate at MenuPosition in world space or relative to its parent?
            // GameObject weaponSlot = Instantiate(_weaponSlotPrefab, gameAndMenuPosition.MenuPosition, Quaternion.identity, _shipImage.transform);
            GameObject weaponSlot = Instantiate(_weaponSlotPrefab, _shipImage.transform);
            weaponSlot.transform.localPosition = gameAndMenuPosition.MenuPosition;

            _weaponSlots.Add(weaponSlot.GetComponent<WeaponSlot>());
        }*/
    }

    public void DisplayWeapon()
    {
        //Weapon weapon = _weaponsSO.Weapons[_weaponIndex].WeaponPrefab.GetComponent<Weapon>();
        Weapon weapon = _ownedWeapons[_weaponIndex].GetComponent<Weapon>();

        _weaponName.text = weapon.gameObject.name;
        _weaponDescription.text = weapon.Description;
        _weaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        _damage.text = $"DAMAGE: {weapon.Damage}";
        _fireRate.text = $"FIRE RATE: {weapon.FireRate}";
    }

    // Move these four methods to WeaponSlot? Probably. 
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
        if (_weaponIndex >= _ownedWeapons.Count)
        {
            _weaponIndex = 0;
        }
        DisplayWeapon();
    }

    public void PreviousWeapon()
    {
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _ownedWeapons.Count - 1;
        }
        DisplayWeapon();
    }

    public void NextLevel()
    {
        if (_gameplayStatisticsSO.LevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_gameplayStatisticsSO.LevelIndex);
        }
        else
        {
            // Game Over
            Debug.Log("GAME OVER");
        }
    }
}