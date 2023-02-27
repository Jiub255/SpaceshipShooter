using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
	[SerializeField]
	private List<Vector3> _weaponPositions = new List<Vector3>();

	public List<Vector3> WeaponPositions { get { return _weaponPositions; } }
}