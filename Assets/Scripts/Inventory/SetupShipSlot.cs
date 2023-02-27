using UnityEngine;
using UnityEngine.UI;

public class SetupShipSlot : MonoBehaviour
{
	[SerializeField]
	private Image _icon;
	[SerializeField]
	private Button _button;
	[SerializeField]
	private CurrentShipSO _currentShipSO;

	private ShipOwned _ship;
	private ShipInfo _shipInfo;

	public void SetupSlot(ShipOwned ship)
    {
		_ship = ship;
		_shipInfo = ship.ShipPrefab.GetComponentInChildren<ShipInfo>();
		_icon.sprite = ship.ShipPrefab.GetComponent<SpriteRenderer>().sprite;
		//_icon.enabled = true;
		//_button.interactable = true;
    }

	public void OnClickButton()
    {
		// Set this as your "current ship". 
		_currentShipSO.currentShipPrefab = _ship.ShipPrefab;
    }
}