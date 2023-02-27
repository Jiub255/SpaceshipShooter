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

    [SerializeField, Header("Display")]
    private Image _shipImage;
    [SerializeField]
    private Image _weaponImage;
    [SerializeField]
    private TextMeshProUGUI _weaponName;
    [SerializeField]
    private TextMeshProUGUI _weaponDescription;
    [SerializeField]
    private TextMeshProUGUI _damage;
    [SerializeField]
    private TextMeshProUGUI _fireRate;
    [SerializeField]
    private Transform _weaponSelector;

    private int _weaponIndex;
    private Weapons _weapons;
    private int _slotIndex;

    private void OnEnable()
    {
        _weapons = _currentShipSO.currentShipPrefab.GetComponentInChildren<Weapons>();
        _weaponSelector.position = _weapons.WeaponPositions[0];

        InitializeMenu();
        DisplayWeapon();
    }

    public void NextSlot()
    {
        _slotIndex++;
        if (_slotIndex >= _weapons.WeaponPositions.Count)
        {
            _slotIndex = 0;
        }
    }

    public void PreviousSlot()
    {
        _slotIndex--;
        if (_slotIndex < 0)
        {
            _slotIndex = _weapons.WeaponPositions.Count - 1;
        }
    }

    public void NextWeapon()
    {
        _weaponIndex++;
        if (_weaponIndex >= _weaponsSO.weaponPrefabs.Count)
        {
            _weaponIndex = 0;
        }
    }

    public void PreviousWeapon()
    {
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _weaponsSO.weaponPrefabs.Count - 1;
        }
    }

    private void InitializeMenu()
    {
        _shipImage.sprite = _currentShipSO.currentShipPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    private void DisplayWeapon()
    {
        Weapon weapon = _weaponsSO.weaponPrefabs[_weaponIndex].GetComponent<Weapon>();

        _weaponName.text = weapon.gameObject.name;
        _weaponDescription.text = weapon.Description;
        _weaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        _damage.text = $"DAMAGE: {weapon.Damage}";
        _fireRate.text = $"FIRE RATE: {weapon.FireRate}";
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