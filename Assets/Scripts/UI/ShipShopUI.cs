using UnityEngine;

public class ShipShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _slotPrefab;

    [SerializeField]
    private Transform _slotParent;

    [SerializeField]
    private ShipInventorySO _shopShipsSO;

    [SerializeField]
    private ShipInventorySO _ownedShipsSO;

    private void OnEnable()
    {
        PopulateShopMenu();
    }

    private void PopulateShopMenu()
    {
        ClearShopMenu();

        foreach (GameObject shipPrefab in _shopShipsSO.shipPrefabs)
        {
            // Only display ships you don't own. 
            if (!_ownedShipsSO.shipPrefabs.Contains(shipPrefab))
            {
                GameObject slotInstance = Instantiate(_slotPrefab, _slotParent);

                slotInstance.transform.GetComponent<BuyShipSlot>().SetupSlot(shipPrefab);
            }
            // If an owned ship somehow ends up on the shop list, remove it. 
            else
            {
                _shopShipsSO.shipPrefabs.Remove(shipPrefab);
            }
        }
    }

    private void ClearShopMenu()
    {
        foreach (Transform child in _slotParent)
        {
            Destroy(child.gameObject);
        }
    }
}