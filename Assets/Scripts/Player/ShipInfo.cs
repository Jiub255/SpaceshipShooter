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
	private float _topSpeed = 10f;
	[SerializeField, Range(0.1f, 3f), Tooltip("Higher values will give you a heavier feeling ship")]
	private float _timeToTopSpeed = 0.1f;
	[SerializeField]
	private int _maxHealth = 10;
	[SerializeField]
	private int _cost = 10;
	[SerializeField]
	private GameObject _menuPrefab;

	public string Name { get { return _name; } }
	public string Description { get { return _description; } }
	public float TopSpeed { get { return _topSpeed; } }
	public float TimeToTopSpeed { get { return _timeToTopSpeed; } }
	public int MaxHealth { get { return _maxHealth; } }
	public int Cost { get { return _cost; } }
	public GameObject MenuPrefab { get { return _menuPrefab; } }
}