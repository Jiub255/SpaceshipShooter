using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Weapon Positions SO", menuName = "Scriptable Objects/Weapon Positions SO")]
public class WeaponAndGamePositionsSO : ScriptableObject
{
	public List<WeaponAndGamePosition> WeaponAndGamePositions;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

[System.Serializable]
public class WeaponAndGamePosition
{
	public int WeaponIndex; 
	public Vector3 GamePosition; 
}