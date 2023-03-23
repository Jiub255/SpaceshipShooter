using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons SO",
    menuName = "Scriptable Objects/Weapons SO")]
public class AllWeaponsListSO : ScriptableObject
{
    public List<WeaponOwned> Weapons = new();

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

[System.Serializable]
public class WeaponOwned
{
    public GameObject WeaponPrefab;
    public bool Owned = false;
}