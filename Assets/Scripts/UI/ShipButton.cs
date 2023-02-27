using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipButton : MonoBehaviour
{
	public static event Action<int> OnClickShipButton;

	[SerializeField]
	private TextMeshProUGUI _name;
	[SerializeField]
	private Image _shipIcon;
	[SerializeField]
	private Image _greyFilter; 
	[SerializeField]
	private IntSO _coinsSO;

	private ShipOwned _ship;
	private ShipInfo _shipInfo;
	private int _index;

	public void SetupButton(ShipOwned ship, int index)
	{
		_ship = ship;
		_shipInfo = _ship.ShipPrefab.GetComponentInChildren<ShipInfo>();
		_shipIcon.sprite = ship.ShipPrefab.GetComponent<SpriteRenderer>().sprite;
		_name.text = _shipInfo.Name;
		_index = index;
		if (_ship.Owned)
        {
			_greyFilter.enabled = false;
        }
        else
        {
			_greyFilter.enabled = true;
        }
	}

	public void OnClickButton()
	{
		// Set ship in display window. 
		OnClickShipButton?.Invoke(_index);
	}
}