using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponsUI : MonoBehaviour
{
    [SerializeField]
    private AllWeaponsListSO _weaponsSO;
    [SerializeField]
    private IntSO _coinsSO;

    [SerializeField]
    private GameObject _weaponButtonPrefab;
    [SerializeField]
    private Transform _buttonParent;

    // Display ship
    [SerializeField]
    private TextMeshProUGUI _weaponName;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private Image _weaponIcon;
    [SerializeField]
    private GameObject _buyButton;
    [SerializeField]
    private TextMeshProUGUI _cost;
    [SerializeField]
    private TextMeshProUGUI _damage;
    [SerializeField]
    private TextMeshProUGUI _fireRate;

    private int _index;

    private void OnEnable()
    {
        PopulateShopMenu();
        _index = 0;
        DisplayWeapon();

        WeaponButton.OnClickWeaponButton += SetWeapon;
    }

    private void OnDisable()
    {
        WeaponButton.OnClickWeaponButton -= SetWeapon;
    }

    private void SetWeapon(int index)
    {
        _index = index;
        // Pass index or keep variable?
        DisplayWeapon();
    }

    public void NextWeapon()
    {
        _index++;
        if (_index >= _weaponsSO.Weapons.Count)
        {
            _index = 0;
        }
        DisplayWeapon();
    }

    public void PreviousWeapon()
    {
        _index--;
        if (_index < 0)
        {
            _index = _weaponsSO.Weapons.Count - 1;
        }
        DisplayWeapon();
    }

    private void DisplayWeapon()
    {
        WeaponInfo weaponInfo = _weaponsSO.Weapons[_index].WeaponPrefab.GetComponent<WeaponInfo>();

        _weaponName.text = weaponInfo.Name;
        _description.text = weaponInfo.Description;
        _weaponIcon.sprite = _weaponsSO.Weapons[_index].WeaponPrefab.GetComponent<SpriteRenderer>().sprite;
        if (_weaponsSO.Weapons[_index].Owned)
        {
            _buyButton.SetActive(false);
        }
        else
        {
            _cost.text = $"COST: {weaponInfo.Cost}";
            _buyButton.SetActive(true);
        }
        _damage.text = $"DAMAGE: {weaponInfo.Damage}";
        _fireRate.text = $"FIRE RATE: {weaponInfo.FireRate}";
    }

    public void BuyWeapon()
    {
        WeaponInfo weaponInfo = _weaponsSO.Weapons[_index].WeaponPrefab.GetComponent<WeaponInfo>();

        // If you have enough money, 
        if (_coinsSO.Value >= weaponInfo.Cost)
        {
            // Pay the cost of the ship. 
            _coinsSO.Value -= weaponInfo.Cost;

            // Set "Owned" to true. 
            _weaponsSO.Weapons[_index].Owned = true;

            // ShipShopUI.PopulateMenu(); 
            PopulateShopMenu();
            DisplayWeapon(); 
        }
        else
        {
            Debug.Log("Not enough money.");
        }
    }

    private void PopulateShopMenu()
    {
        ClearShopMenu();

       // foreach (ShipOwned ship in _shipsSO.ships)
        for (int i = 0; i < _weaponsSO.Weapons.Count; i++)
        {
            GameObject slotInstance = Instantiate(_weaponButtonPrefab, _buttonParent);

            slotInstance.transform.GetComponent<WeaponButton>().SetupButton(_weaponsSO.Weapons[i], i);
        }
    }

    private void ClearShopMenu()
    {
        foreach (Transform child in _buttonParent)
        {
            Destroy(child.gameObject);
        }
    }
}