using UnityEngine;

public class SOQuitManager : MonoBehaviour
{
    [SerializeField]
    private LevelIndexSO _levelIndexSO;
    [SerializeField]
    private IntSO _coinsSO;
    [SerializeField]
    private WeaponAndGamePositionsSO _ship1WAGPSO;
    [SerializeField]
    private WeaponAndGamePositionsSO _ship2WAGPSO;
    [SerializeField]
    private WeaponAndGamePositionsSO _ship3WAGPSO;
    [SerializeField]
    private AllShipsListSO _shipsSO;
    [SerializeField]
    private AllWeaponsListSO _weaponsSO;
    [SerializeField]
    private CurrentShipSO _currentShipSO;
    [SerializeField]
    private GameplayStatisticsSO _gameplayStatisticsSO;

    private void OnApplicationQuit()
    {
        _levelIndexSO.Value = 1;
        _coinsSO.Value = 0;

        // Individual ships' weapon and game positions 
        foreach (WeaponAndGamePosition wagp in _ship1WAGPSO.WeaponAndGamePositions)
        {
            wagp.WeaponIndex = 0;
        }
        foreach (WeaponAndGamePosition wagp in _ship2WAGPSO.WeaponAndGamePositions)
        {
            wagp.WeaponIndex = 0;
        }
        foreach (WeaponAndGamePosition wagp in _ship3WAGPSO.WeaponAndGamePositions)
        {
            wagp.WeaponIndex = 0;
        }

        // All ships and all weapons lists
        for (int i = _shipsSO.Ships.Count - 1; i > 0; i--)
        {
            _shipsSO.Ships[i].Owned = false;
        }
        for (int i = _weaponsSO.Weapons.Count - 1; i > 0; i--)
        {
            _weaponsSO.Weapons[i].Owned = false;
        }

        // Currently selected ship
        _currentShipSO.currentShipPrefab = _shipsSO.Ships[0].ShipPrefab;

        // Gameplay Statistics
        _gameplayStatisticsSO.TimePlayed = 0;

        _gameplayStatisticsSO.TotalKills = 0;
        _gameplayStatisticsSO.Enemy1Kills = 0;
        _gameplayStatisticsSO.Enemy2Kills = 0;

        _gameplayStatisticsSO.ProjectilesFired = 0;
        _gameplayStatisticsSO.Bullet1sFired = 0;
        _gameplayStatisticsSO.Bullet2sFired = 0;

        _gameplayStatisticsSO.CoinsCollected = 0;
        _gameplayStatisticsSO.CoinsSpent = 0;
        _gameplayStatisticsSO.MostCoinsHeld = 0;
    }
}