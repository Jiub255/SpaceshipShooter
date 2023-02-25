using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
	[SerializeField]
	private string _name = "Enter Ship Name";
	[SerializeField, TextArea(1,20)]
	private string _description;
	[SerializeField]
	private Sprite _icon; 
	[SerializeField]
	private IntSO _coinsSO;
	[SerializeField]
	private int _cost = 10;

	public string Name { get { return _name; } }
	public string Description { get { return _description; } }
	public Sprite Icon { get { return _icon; } }
	public IntSO CoinsSO { get { return _coinsSO; } }
	public int Cost { get { return _cost; } }
}