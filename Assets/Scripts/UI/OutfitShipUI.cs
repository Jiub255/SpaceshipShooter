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
    private AllWeaponsListSO _weaponsSO;

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
    private Transform _shipMenuParent;
    [SerializeField]
    private GameObject _weaponSlotPrefab;

    private GameObject _shipMenuPrefab;
    private List<GameObject> _ownedWeapons = new();
    private int _weaponIndex;
    private List<WeaponSlot> _weaponSlots = new();
    private int _slotIndex;
    private WeaponAndGamePositions _weaponAndGamePositions;

    public List<GameObject> OwnedWeapons { get { return _ownedWeapons; } }
    public int WeaponIndex { get { return _weaponIndex; } }

    private void OnEnable()
    {
        _weaponIndex = 0;
        _slotIndex = 0;

        // Get the ship menu prefab from the current ship SO. 
        _shipMenuPrefab = _currentShipSO.currentShipPrefab.GetComponent<ShipInfo>().MenuPrefab;
        _weaponAndGamePositions = _currentShipSO.currentShipPrefab.GetComponent<WeaponAndGamePositions>();

        // Make a list of all owned weapons, so this foreach loop isn't necessary every time the index changes. 
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
        // Instantiate ship menu prefab. 
        GameObject shipMenuInstance = Instantiate(_shipMenuPrefab, _shipMenuParent);
        shipMenuInstance.transform.localPosition = Vector3.zero;

        List<Vector3> slotPositions = new();
        foreach (Transform slotPosition in shipMenuInstance.transform)
        {
            slotPositions.Add(slotPosition.localPosition);
        }

        // Instantiate (and deactivate) weapon slots. 
        foreach (Vector3 slotPosition in slotPositions)
        {
            GameObject slotObject = Instantiate(_weaponSlotPrefab, shipMenuInstance.transform);
            slotObject.transform.localPosition = slotPosition;

            WeaponSlot weaponSlot = slotObject.GetComponent<WeaponSlot>();
            _weaponSlots.Add(weaponSlot);
            weaponSlot.SetupSlot(this);
            slotObject.SetActive(false);
        }

        // Activate the first slot (there should always be at least one). 
        _weaponSlots[0].gameObject.SetActive(true);
    }

    public void DisplayWeapon()
    {
        Weapon weapon = _ownedWeapons[_weaponIndex].GetComponent<Weapon>();

        _weaponName.text = weapon.Name;
        _weaponDescription.text = weapon.Description;
        _weaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        _damage.text = $"DAMAGE: {weapon.Damage}";
        _fireRate.text = $"FIRE RATE: {weapon.FireRate}";
    }

    // Next four methods called by WeaponSlot class, and those methods get called by
    // the four buttons on the weapon slot. 
    public void NextSlot()
    {
        // Deactivate current slot. 
        _weaponSlots[_slotIndex].gameObject.SetActive(false);

        // Increment index. 
        _slotIndex++;
        if (_slotIndex >= _weaponSlots.Count)
        {
            _slotIndex = 0;
        }

        // Activate new current slot. 
        _weaponSlots[_slotIndex].gameObject.SetActive(true);
    }

    public void PreviousSlot()
    {
        // Deactivate current slot. 
        _weaponSlots[_slotIndex].gameObject.SetActive(false);

        // Increment index. 
        _slotIndex--;
        if (_slotIndex < 0)
        {
            _slotIndex = _weaponSlots.Count - 1;
        }

        // Activate new current slot. 
        _weaponSlots[_slotIndex].gameObject.SetActive(true);
    }

    public void NextWeapon()
    {
        _weaponIndex++;
        if (_weaponIndex >= _ownedWeapons.Count)
        {
            _weaponIndex = 0;
        }
        DisplayWeapon();
        // TODO: Need to set the WeaponIndex on this slot as well. 
        _weaponAndGamePositions.WeaponPositions[_slotIndex].WeaponIndex = _weaponIndex;
    }

    public void PreviousWeapon()
    {
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _ownedWeapons.Count - 1;
        }
        DisplayWeapon();
        // TODO: Need to set the WeaponIndex on this slot as well. 
        _weaponAndGamePositions.WeaponPositions[_slotIndex].WeaponIndex = _weaponIndex;
    }

    // Called from UI button. 
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