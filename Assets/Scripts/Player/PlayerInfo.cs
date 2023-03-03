using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
	[SerializeField]
	private IntSO _coinsSO;
	[SerializeField]
	private WeaponAndGamePositionsSO _weaponAndGamePositionsSO;

	public IntSO CoinsSO { get { return _coinsSO; } }
	public WeaponAndGamePositionsSO WeaponAndGamePositionsSO { get { return _weaponAndGamePositionsSO; } }
}