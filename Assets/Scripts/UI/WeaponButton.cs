using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
	public static event Action<int> OnClickWeaponButton;

	[SerializeField]
	private TextMeshProUGUI _name;
	[SerializeField]
	private Image _weaponIcon;
	[SerializeField]
	private Image _greyFilter; 
	[SerializeField]
	private IntSO _coinsSO;

	private WeaponOwned _weapon;
	private PlayerWeapon _weaponInfo;
	private int _index;

	public void SetupButton(WeaponOwned weapon, int index)
	{
		_weapon = weapon;
		_weaponInfo = _weapon.WeaponPrefab.GetComponentInChildren<PlayerWeapon>();
		_weaponIcon.sprite = weapon.WeaponPrefab.GetComponent<SpriteRenderer>().sprite;
		_name.text = _weaponInfo.Name;
		_index = index;
		if (_weapon.Owned)
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
		// Set weapon in display window. 
		// Heard by ShopWeaponUI. 
		OnClickWeaponButton?.Invoke(_index);
	}
}