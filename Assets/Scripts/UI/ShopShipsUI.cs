using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopShipsUI : MonoBehaviour
{
    [SerializeField]
    private AllShipsListSO _shipsSO;
    [SerializeField]
    private IntSO _coinsSO;
    [SerializeField]
    private TextMeshProUGUI _coinsText;

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
        _index = 0;
        DisplayShip();
        UpdateCoins();

        ShipButton.OnClickShipButton += SetShip;
    }

    private void OnDisable()
    {
        ShipButton.OnClickShipButton -= SetShip;
    }

    private void UpdateCoins()
    {
        _coinsText.text = $"COINS: {_coinsSO.Value}";
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
        if (_index >= _shipsSO.Ships.Count)
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
            _index = _shipsSO.Ships.Count - 1;
        }
        DisplayShip();
    }

    private void DisplayShip()
    {
        ShipInfo shipInfo = _shipsSO.Ships[_index].ShipPrefab.GetComponent<ShipInfo>();

        _shipName.text = shipInfo.Name;
        _description.text = shipInfo.Description;
        _shipIcon.sprite = _shipsSO.Ships[_index].ShipPrefab.GetComponent<SpriteRenderer>().sprite;
        if (_shipsSO.Ships[_index].Owned)
        {
            _buyButton.SetActive(false);
        }
        else
        {
            _cost.text = $"COST: {shipInfo.Cost}";
            _buyButton.SetActive(true);
        }
        _defense.text = $"DEFENSE: {shipInfo.MaxHealth}";
        _speed.text = $"SPEED: {shipInfo.TopSpeed}";
    }

    public void BuyShip()
    {
        ShipInfo shipInfo = _shipsSO.Ships[_index].ShipPrefab.GetComponent<ShipInfo>();

        // If you have enough money, 
        if (_coinsSO.Value >= shipInfo.Cost)
        {
            // Pay the cost of the ship. 
            _coinsSO.Value -= shipInfo.Cost;

            // Set "Owned" to true. 
            _shipsSO.Ships[_index].Owned = true;

            // ShipShopUI.PopulateMenu(); 
            PopulateShopMenu();
            DisplayShip(); 
            UpdateCoins();
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