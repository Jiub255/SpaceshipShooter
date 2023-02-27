using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyShipSlot : MonoBehaviour
{
	public static event Action OnBuyShip;

	[SerializeField]
	private Image _icon;
	[SerializeField]
	private Button _button;
	[SerializeField]
	private IntSO _coinsSO;
	[SerializeField]
	private ShipInventorySO _shipsSO;

	private ShipOwned _ship;
	private ShipInfo _shipInfo;

	public void SetupSlot(ShipOwned ship)
    {
		_ship = ship;
		_shipInfo = _ship.shipPrefab.GetComponentInChildren<ShipInfo>();
		_icon.sprite = _shipInfo.Icon;
		_icon.enabled = true;
		_button.interactable = true;
    }

	public void OnClickButton()
    {
		// If you have enough money, 
		if (_coinsSO.Value >= _shipInfo.Cost)
        {
			// Pay the cost of the ship. 
			_coinsSO.Value -= _shipInfo.Cost;

			// Set "Owned" to true. 
			_ship.owned = true;

			// ShipShopUI.PopulateMenu(); 
			OnBuyShip?.Invoke();
        }
        else
        {
			Debug.Log("Not enough money.");
        }
    }
}