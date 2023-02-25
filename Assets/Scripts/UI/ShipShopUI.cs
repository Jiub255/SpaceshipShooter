using UnityEngine;

public class ShipShopUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject SlotPrefab;

    [SerializeField]
    protected Transform SlotParent;

    [SerializeField]
    private ShipInventorySO _shopShipsSO;

    private void OnEnable()
    {
        PopulateShopMenu();
    }

    private void PopulateShopMenu()
    {
        ClearShopMenu();

        foreach (GameObject shipPrefab in _shopShipsSO.shipPrefabs)
        {
            GameObject slotInstance = Instantiate(SlotPrefab, SlotParent);

            slotInstance.transform.GetComponent<ShipSlot>().SetupSlot(shipPrefab);
        }
    }

    private void ClearShopMenu()
    {
        foreach (Transform child in SlotParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void StopShopping()
    {
        // Load Setup Scene (where you choose which ship to use, outfit it, etc.). 

    }
}