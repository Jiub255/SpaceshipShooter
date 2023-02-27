using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Inventory SO",
    menuName = "Scriptable Objects/Ship Inventory SO")]
public class ShipInventorySO : ScriptableObject
{
	public List<ShipOwned> ships = new List<ShipOwned>();
}

[System.Serializable]
public class ShipOwned
{
    public GameObject shipPrefab;
    public bool owned = false;
}