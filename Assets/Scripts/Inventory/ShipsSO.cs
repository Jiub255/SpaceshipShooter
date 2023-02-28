using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Inventory SO",
    menuName = "Scriptable Objects/Ship Inventory SO")]
public class ShipsSO : ScriptableObject
{
	public List<ShipOwned> Ships = new List<ShipOwned>();
}

[System.Serializable]
public class ShipOwned
{
    public GameObject ShipPrefab;
    public bool Owned = false;
}