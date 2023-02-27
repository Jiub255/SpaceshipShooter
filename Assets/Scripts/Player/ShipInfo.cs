using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfo : MonoBehaviour
{
	[SerializeField]
	private string _name = "Enter Ship Name";
	[SerializeField, TextArea(1,20)]
	private string _description;
	[SerializeField]
	private int _cost = 10;
	[SerializeField]
	private Sprite _icon; 

	public string Name { get { return _name; } }
	public string Description { get { return _description; } }
	public int Cost { get { return _cost; } }
	public Sprite Icon { get { return _icon; } }
}