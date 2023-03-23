using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseShipUI : MonoBehaviour
{
    [SerializeField]
    private AllShipsListSO _shipsSO;
    [SerializeField]
    private IntSO _coinsSO;
    [SerializeField]
    private CurrentShipSO _currentShipSO;

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
    private TextMeshProUGUI _defense;
    [SerializeField]
    private TextMeshProUGUI _speed;

    private int _index;
    private List<GameObject> _ownedShips = new();

    private void OnEnable()
    {
        // TODO: Make _ownedShips list.
        foreach (ShipOwned shipOwned in _shipsSO.Ships)
        {
            if (shipOwned.Owned)
            {
                _ownedShips.Add(shipOwned.ShipPrefab);
            }
        }

        _index = 0;
        PopulateShopMenu();
        DisplayShip(); 

        ShipButton.OnClickShipButton += SetShip;
    }

    private void OnDisable()
    {
        ShipButton.OnClickShipButton -= SetShip;
    }

    private void SetShip(int index)
    {
        _index = index;

        DisplayShip();
    }

    public void NextShip()
    {
        _index++;
        if (_index >= _ownedShips.Count)
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
            _index = _ownedShips.Count - 1;
        }
        DisplayShip();
    }

    private void DisplayShip()
    {
        ShipInfo shipInfo = _ownedShips[_index].GetComponent<ShipInfo>();

        _shipName.text = shipInfo.Name;
        _description.text = shipInfo.Description;
        _shipIcon.sprite = _ownedShips[_index].GetComponent<SpriteRenderer>().sprite;
        _defense.text = $"DEFENSE: {shipInfo.MaxHealth}";
        _speed.text = $"SPEED: {shipInfo.TopSpeed}";

        _currentShipSO.currentShipPrefab = _ownedShips[_index];
    }

    // Called from UI button. 
    public void SelectShip()
    {
        _currentShipSO.currentShipPrefab = _ownedShips[_index];
    }

    private void PopulateShopMenu()
    {
        ClearShopMenu();

        // Hack fix for different indexes in _shipsSO.Ships and _ownedShips. 
        // Definitely a cleaner way to do this, but this'll do for now. 
        int ownedShipsIndex = 0;
        //for (int i = 0; i < _shipsSO.Ships.Count; i++)
        foreach (ShipOwned ship in _shipsSO.Ships)
        {
            if (ship.Owned)
            {
                GameObject slotInstance = Instantiate(_shipButtonPrefab, _buttonParent);

                slotInstance.transform.GetComponent<ShipButton>().SetupButton(ship, ownedShipsIndex);

                ownedShipsIndex++;
            }
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