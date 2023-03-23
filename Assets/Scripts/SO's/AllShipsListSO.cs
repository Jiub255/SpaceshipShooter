using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ships SO",
    menuName = "Scriptable Objects/Ships SO")]
public class AllShipsListSO : ScriptableObject
{
	public List<ShipOwned> Ships = new();

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

[System.Serializable]
public class ShipOwned
{
    public GameObject ShipPrefab;
    public bool Owned = false;
}