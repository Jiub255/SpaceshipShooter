using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    // To store time/date of save, for finding most recent save for continue button
    public long LastUpdated;

    // Save data variables 
    public string PlayerName;
    public int Coins;
    public List<bool> ShipsOwned;

    // Put new game initialization values in here
    public GameData()
    {
        PlayerName = "Enter Name";
        Coins = 0;
        ShipsOwned = new List<bool>() { true, false, false, false, false, false };
    }

    // Do an actual calculation here eventually
    public int GetPercentageComplete()
    {
        return 69;
    }
}