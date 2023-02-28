using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
	public List<WeaponPosition> WeaponPositions = new();
}

[System.Serializable]
public class WeaponPosition
{
	public Vector3 Position;
	public int WeaponIndex;
}