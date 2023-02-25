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
		// Set this as your "current ship". 
		_currentShipSO.currentShipPrefab = _shipPrefab;
    }
}