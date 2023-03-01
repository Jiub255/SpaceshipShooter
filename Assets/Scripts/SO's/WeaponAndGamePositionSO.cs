using UnityEngine;
// For each ship prefab, make a list of WeaponPositionSO's and set the Position part.
// Then the WeaponIndex part gets set in game. 
[System.Serializable, CreateAssetMenu(fileName = "New Weapon Position SO", menuName = "Scriptable Objects/Weapon Position SO")]
public class WeaponAndGamePositionSO : ScriptableObject
{
	public Vector3 Position;
	public int WeaponIndex;
}