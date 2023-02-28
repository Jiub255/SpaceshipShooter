using UnityEngine;

// Might make a ship info base class, and have Player and Enemy (and Boss) infos inherit and add. 
// They all need name, speed, maxHealth, sprite. 
// Player ships need description and cost. 
// Enemy ships need loot dropped. 
// Bosses need loot dropped. Maybe some other unique data. 
public class ShipInfo : MonoBehaviour
{
	[SerializeField]
	private string _name = "Enter Ship Name";
	[SerializeField, TextArea(1,20)]
	private string _description = "Enter Ship's Description";
	[SerializeField]
	private float _speed = 10;
	[SerializeField]
	private int _maxHealth = 10;
	[SerializeField]
	private int _cost = 10;
	[SerializeField]
	private GameObject _menuPrefab;

	public string Name { get { return _name; } }
	public string Description { get { return _description; } }
	public float Speed { get { return _speed; } }
	public int MaxHealth { get { return _maxHealth; } }
	public int Cost { get { return _cost; } }
	public GameObject MenuPrefab { get { return _menuPrefab; } }
}