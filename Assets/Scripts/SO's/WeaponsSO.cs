using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons SO",
    menuName = "Scriptable Objects/Weapons SO")]
public class WeaponsSO : ScriptableObject
{
    public List<GameObject> weaponPrefabs = new List<GameObject>();
}