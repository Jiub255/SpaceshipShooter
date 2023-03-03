using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gameplay Statistics SO",
    menuName = "Scriptable Objects/Gameplay Statistics SO")]
public class GameplayStatisticsSO : ScriptableObject
{
    public double TimePlayed;

    public int TotalKills;
    public int Enemy1Kills;
    public int Enemy2Kills;

    public int ProjectilesFired;
    public int Bullet1sFired;
    public int Bullet2sFired;

    public int CoinsCollected;
    public int CoinsSpent;
    public int MostCoinsHeld;
}