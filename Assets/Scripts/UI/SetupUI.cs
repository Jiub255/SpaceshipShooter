using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _slotPrefab;

    [SerializeField]
    private Transform _slotParent;

    [SerializeField]
	private ShipInventorySO _ownedShipsSO;

    // First, choose which ship. Use SetupSlot prefab similar to ShipSlot, but with a different button action. 
    private void OnEnable()
    {
        PopulateSetupMenu();
    }

    private void PopulateSetupMenu()
    {
        ClearSetupMenu();

        foreach (GameObject shipPrefab in _ownedShipsSO.shipPrefabs)
        {
            GameObject slotInstance = Instantiate(_slotPrefab, _slotParent);

            slotInstance.transform.GetComponent<SetupShipSlot>().SetupSlot(shipPrefab);
        }
    }

    private void ClearSetupMenu()
    {
        foreach (Transform child in _slotParent)
        {
            Destroy(child.gameObject);
        }
    }

    // Second, choose which guns. 


    // Load next level. 
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}