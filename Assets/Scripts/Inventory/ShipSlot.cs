using UnityEngine;
using UnityEngine.UI;

public class ShipSlot : MonoBehaviour
{
	[SerializeField]
	private Image _icon;
	[SerializeField]
	private Button _button;
	[SerializeField]
	private IntSO _coinsSO;
	[SerializeField]
	private ShipInventorySO _shipInventorySO;
	[SerializeField]
	private ShipInventorySO _shopShipsSO;

	private GameObject _shipPrefab;
	private PlayerInfo _playerInfo;

	public void SetupSlot(GameObject shipPrefab)
    {
		_shipPrefab = shipPrefab;
		_playerInfo = _shipPrefab.GetComponent<PlayerInfo>();
		_icon.sprite = _playerInfo.Icon;
		_icon.enabled = true;
		_button.interactable = true;
    }

	public void ClearSlot()
    {
		_shipPrefab = null;
		_icon.sprite = null;
		_icon.enabled = false;
		_button.interactable = false;
    }

	public void OnClickButton()
    {
		// If you have enough money, 
		if (_coinsSO.Value >= _playerInfo.Cost)
        {
			// Pay the cost of the ship. 
			_coinsSO.Value -= _playerInfo.Cost;

			// Add ship prefab to ship inventory SO. 
			_shipInventorySO.shipPrefabs.Add(_shipPrefab);

			// Remove ship prefab from shop ships SO. 
			_shopShipsSO.shipPrefabs.Remove(_shipPrefab);

			// Clear slot.  
			ClearSlot();
        }
        else
        {
			Debug.Log("Not enough money.");
        }
    }
}