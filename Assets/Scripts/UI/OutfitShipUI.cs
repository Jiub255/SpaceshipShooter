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

    private ShipInfo _shipInfo;
    private int _index;

    private void OnEnable()
    {
        _shipInfo = GetComponentInChildren<ShipInfo>();

        InitializeMenu();
    }

    private void InitializeMenu()
    {
        _shipImage.sprite = _currentShipSO.currentShipPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    private void DisplayWeapon()
    {
        Weapon weapon = _weaponsSO.weaponPrefabs[_index].GetComponent<Weapon>();

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