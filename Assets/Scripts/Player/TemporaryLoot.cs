using UnityEngine;

public class TemporaryLoot : MonoBehaviour
{
	// Temporary store data about what the player has gotten (coins, items, exp., etc.) during the level before putting it into the SO's,
	// in case they die and it needs to get reset. 
	public int Coins { get; set; }
    private PlayerInfo _playerInfo;

    // Reset everything here. 
    private void OnEnable()
    {
        Coins = 0;

        _playerInfo = GetComponent<PlayerInfo>();

        LevelEnder.OnLevelOver += AddLootToSOs;
    }

    private void OnDisable()
    {
        LevelEnder.OnLevelOver -= AddLootToSOs;
    }

    private void AddLootToSOs()
    {
        _playerInfo.CoinsSO.Value += Coins;
    }
}