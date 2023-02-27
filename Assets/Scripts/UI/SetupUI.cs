using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _slotPrefab;

    [SerializeField]
    private Transform _slotParent;

    [SerializeField]
	private ShipInventorySO _shipsSO;

    private void OnEnable()
    {
        PopulateSetupMenu();
    }

    private void PopulateSetupMenu()
    {
        ClearSetupMenu();

        foreach (ShipOwned ship in _shipsSO.ships)
        {
            if (ship.owned)
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

    // TODO: Keep a currentLevel index, and increase it when you pass a level. 
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}