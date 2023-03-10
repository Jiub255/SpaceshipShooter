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

    private void OnEnable()
    {
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
        _defense.text = $"DEFENSE: {shipInfo.MaxHealth}";
        _speed.text = $"SPEED: {shipInfo.Speed}";

        _currentShipSO.currentShipPrefab = _shipsSO.Ships[_index].ShipPrefab;
    }

    // Called from UI button. 
    public void SelectShip()
    {
        _currentShipSO.currentShipPrefab = _shipsSO.Ships[_index].ShipPrefab;
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