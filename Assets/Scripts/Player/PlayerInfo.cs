using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
	[SerializeField]
	private IntSO _coinsSO;
	public IntSO CoinsSO { get { return _coinsSO; } }
}