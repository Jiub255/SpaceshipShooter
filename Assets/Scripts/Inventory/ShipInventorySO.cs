using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Inventory SO",
    menuName = "Scriptable Objects/Ship Inventory SO")]
public class ShipInventorySO : ScriptableObject
{
	public List<GameObject> shipPrefabs = new List<GameObject>();
}