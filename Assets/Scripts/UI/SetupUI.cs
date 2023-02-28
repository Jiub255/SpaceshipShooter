using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _slotPrefab;

    [SerializeField]
    private Transform _slotParent;

    [SerializeField]
	private ShipsSO _shipsSO;

    [SerializeField]
    private GameplayStatisticsSO _gameplayStatisticsSO;

    private void OnEnable()
    {
        PopulateSetupMenu();
    }

    private void PopulateSetupMenu()
    {
        ClearSetupMenu();

        foreach (ShipOwned ship in _shipsSO.Ships)
        {
            if (ship.Owned)
            {
                GameObject slotInstance = Instantiate(_slotPrefab, _slotParent);

                slotInstance.transform.GetComponent<SetupShipSlot>().SetupSlot(ship);
            }
        }
    }

    private void ClearSetupMenu()
    {
        foreach (Transform child in _slotParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void NextLevel()
    {
        if (_gameplayStatisticsSO.LevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_gameplayStatisticsSO.LevelIndex);
        }
        else
        {
            // Game Over
            Debug.Log("GAME OVER");
        }
    }
}