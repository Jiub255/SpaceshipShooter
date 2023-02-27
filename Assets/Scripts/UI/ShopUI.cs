using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private ShipInventorySO _shipsSO;
    [SerializeField]
    private IntSO _coinsSO;

    [SerializeField]
    private GameObject _shipButtonPrefab;
    [SerializeField]
    private Transform _buttonParent;

    // Display ship
    [SerializeField]
    private TextMeshProUGUI _shipName;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private Image _shipIcon;
    [SerializeField]
    private GameObject _buyButton;
    [SerializeField]
    private TextMeshProUGUI _cost;
    [SerializeField]
    private TextMeshProUGUI _defense;
    [SerializeField]
    private TextMeshProUGUI _speed;

    private int _index;

    private void OnEnable()
    {
        PopulateShopMenu();

        ShipButton.OnClickShipButton += SetShip;
    }

    private void OnDisable()
    {
        ShipButton.OnClickShipButton -= SetShip;
    }

    private void SetShip(int index)
    {
        _index = index;
        // Pass index or keep variable?
        DisplayShip();
    }

    public void NextShip()
    {
        _index++;
        if (_index > 5)
        {
            _index = 0;
        }
        DisplayShip();
    }

    public void PreviousShip()
    {
        _index--;
        if (_index < 0)
        {
            _index = 5;
        }
        DisplayShip();
    }

    private void DisplayShip()
    {
        ShipInfo shipInfo = _shipsSO.Ships[_index].ShipPrefab.GetComponentInChildren<ShipInfo>();

        _shipName.text = shipInfo.Name;
        _description.text = shipInfo.Description;
        _shipIcon.sprite = _shipsSO.Ships[_index].ShipPrefab.GetComponent<SpriteRenderer>().sprite;
        if (_shipsSO.Ships[_index].Owned)
        {
            _buyButton.SetActive(false);
        }
        else
        {
            _cost.text = $"COST: {shipInfo.Cost.ToString()}";
            _buyButton.SetActive(true);
        }
        _defense.text = $"DEFENSE: {_shipsSO.Ships[_index].ShipPrefab.GetComponent<PlayerHealth>().MaxHealth}";
        _speed.text = $"SPEED: {_shipsSO.Ships[_index].ShipPrefab.GetComponent<PlayerMovement>().Speed}";
    }

    public void BuyShip()
    {
        ShipInfo shipInfo = _shipsSO.Ships[_index].ShipPrefab.GetComponentInChildren<ShipInfo>();

        // If you have enough money, 
        if (_coinsSO.Value >= shipInfo.Cost)
        {
            // Pay the cost of the ship. 
            _coinsSO.Value -= shipInfo.Cost;

            // Set "Owned" to true. 
            _shipsSO.Ships[_index].Owned = true;

            // ShipShopUI.PopulateMenu(); 
            PopulateShopMenu();
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
        for (int i = 0; i < _shipsSO.Ships.Count; i++)
        {
            GameObject slotInstance = Instantiate(_shipButtonPrefab, _buttonParent);

            slotInstance.transform.GetComponent<ShipButton>().SetupButton(_shipsSO.Ships[i], i);
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