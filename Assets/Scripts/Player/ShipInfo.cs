using UnityEngine;

public class ShipInfo : MonoBehaviour
{
	[SerializeField]
	private string _name = "Enter Ship Name";
	[SerializeField, TextArea(1,20)]
	private string _description;
	[SerializeField]
	private int _cost = 10;

	public string Name { get { return _name; } }
	public string Description { get { return _description; } }
	public int Cost { get { return _cost; } }
}