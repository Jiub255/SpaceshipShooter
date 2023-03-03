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
    private IntSO _levelIndexSO;
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
    //private WeaponAndGamePositions _weaponAndGamePositions;
    private GameObject _shipMenuInstance;

    private PlayerInfo _playerInfo;

    public List<GameObject> OwnedWeapons { get { return _ownedWeapons; } }
    public int WeaponIndex { get { return _weaponIndex; } }
    public int SlotIndex { get { return _slotIndex; } }

    private void OnEnable()
    {
        _playerInfo = _currentShipSO.currentShipPrefab.GetComponent<PlayerInfo>();

        _weaponIndex = 0;
        _slotIndex = 0;

        // Get the ship menu prefab from the current ship SO. 
        _shipMenuPrefab = _currentShipSO.currentShipPrefab.GetComponent<ShipInfo>().MenuPrefab;
       // _weaponAndGamePositions = _currentShipSO.currentShipPrefab.GetComponent<WeaponAndGamePositions>();

        // Make a list of all owned weapons, so this foreach loop isn't necessary every time the index changes. 
        foreach (WeaponOwned weapon in _weaponsSO.Weapons)
        {
            if (weapon.Owned)
            {
                _ownedWeapons.Add(weapon.WeaponPrefab);
            }
        }

        Debug.Log($"Owned weapons: {_ownedWeapons.Count}");

        InitializeMenu();
        DisplayWeapon();
    }

    private void InitializeMenu()
    {
        // Instantiate ship menu prefab. 
        _shipMenuInstance = Instantiate(_shipMenuPrefab, _shipMenuParent);
        _shipMenuInstance.transform.localPosition = Vector3.zero;

        // Instantiate weapon slots and set weapon sprites. 
        for (int i = 0; i < /*_weaponAndGamePositions*/_playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions.Count; i++)
        {
            // Set weapon sprite. 
            _shipMenuInstance.transform.GetChild(i).GetComponent<Image>().sprite = 
                _ownedWeapons[/*_weaponAndGamePositions*/_playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions[i].WeaponIndex].GetComponent<SpriteRenderer>().sprite;

            // Instantiate weapon slot. 
            GameObject slotObject = Instantiate(_weaponSlotPrefab, _shipMenuInstance.transform);
            slotObject.transform.localPosition = _shipMenuInstance.transform.GetChild(i).localPosition;

            // Setup weapon slot, add to list, deactivate. 
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
        // Get weapon info. 
        WeaponInfo weapon = _ownedWeapons[_weaponIndex].GetComponent<WeaponInfo>();

        // Set weapon info in UI. 
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

        // Get weapon index of new slot. 
        _weaponIndex = /*_weaponAndGamePositions*/_playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions[_slotIndex].WeaponIndex;
        DisplayWeapon();

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

        // Get weapon index of new slot. 
        _weaponIndex = /*_weaponAndGamePositions*/_playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions[_slotIndex].WeaponIndex;
        DisplayWeapon();

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

        // Set the WeaponIndex on current slot. 
        /*_weaponAndGamePositions*/
        _playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions[_slotIndex].WeaponIndex = _weaponIndex;

        // Set the weapon sprite. 
        _shipMenuInstance.transform.GetChild(_slotIndex).GetComponent<Image>().sprite =
            _ownedWeapons[_weaponIndex].GetComponent<SpriteRenderer>().sprite;
    }

    public void PreviousWeapon()
    {
        _weaponIndex--;
        if (_weaponIndex < 0)
        {
            _weaponIndex = _ownedWeapons.Count - 1;
        }
        DisplayWeapon();

        // Set the WeaponIndex on current slot. 
        /*_weaponAndGamePositions*/
        _playerInfo.WeaponAndGamePositionsSO.WeaponAndGamePositions[_slotIndex].WeaponIndex = _weaponIndex;

        // Set the weapon sprite. 
        _shipMenuInstance.transform.GetChild(_slotIndex).GetComponent<Image>().sprite =
            _ownedWeapons[_weaponIndex].GetComponent<SpriteRenderer>().sprite;
    }

    // Called from UI button. 
    public void NextLevel()
    {
        if (_levelIndexSO.Value < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_levelIndexSO.Value);
        }
        else
        {
            // Game Over
            Debug.Log("GAME OVER");
        }
    }
}