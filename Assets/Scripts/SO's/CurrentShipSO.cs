using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Current Ship SO",
    menuName = "Scriptable Objects/Current Ship SO")]
public class CurrentShipSO : ScriptableObject
{
    public GameObject currentShipPrefab; 
}