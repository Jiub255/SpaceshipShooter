using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons SO",
    menuName = "Scriptable Objects/Weapons SO")]
public class WeaponsSO : ScriptableObject
{
    public List<WeaponOwned> Weapons = new();
}

public class WeaponOwned
{
    public GameObject WeaponPrefab;
    public bool Owned = false;
}