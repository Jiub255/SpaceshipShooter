using UnityEngine;
using UnityEngine.UI;

public class BuyShipSlot : MonoBehaviour
{
	[SerializeField]
	private Image _icon;
	[SerializeField]
	private Button _button;
	[SerializeField]
	private IntSO _coinsSO;
	[SerializeField]
	private ShipInventorySO _ownedShipsSO;
	[SerializeField]
	private ShipInventorySO _shopShipsSO;

	private GameObject _shipPrefab;
	private PlayerInfo _playerInfo;

	public void SetupSlot(GameObject shipPrefab)
    {
		_shipPrefab = shipPrefab;
		_playerInfo = _shipPrefab.GetComponentInChildren<PlayerInfo>();
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
		// If you have enough money, and don't already own the ship. 
		if (_coinsSO.Value >= _playerInfo.Cost && !_ownedShipsSO.shipPrefabs.Contains(_shipPrefab))
        {
			// Pay the cost of the ship. 
			_coinsSO.Value -= _playerInfo.Cost;

			// Add ship prefab to ship inventory SO. 
			_ownedShipsSO.shipPrefabs.Add(_shipPrefab);

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