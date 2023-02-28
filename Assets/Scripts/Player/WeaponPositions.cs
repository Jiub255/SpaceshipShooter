using System.Collections.Generic;
using UnityEngine;

public class WeaponPositions : MonoBehaviour
{
	public List<GameAndMenuPosition> GameAndMenuPositions = new List<GameAndMenuPosition>();
}

public class GameAndMenuPosition
{
	public Vector3 GamePosition;
	public Vector3 MenuPosition;
}