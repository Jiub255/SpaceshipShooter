using UnityEngine;

public class ShipShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _slotPrefab;

    [SerializeField]
    private Transform _slotParent;

    [SerializeField]
    private AllShipsListSO _shipsSO;

    private void OnEnable()
    {
        PopulateShopMenu();

        BuyShipSlot.OnBuyShip += PopulateShopMenu;
    }

    private void OnDisable()
    {
        BuyShipSlot.OnBuyShip -= PopulateShopMenu;
    }

    private void PopulateShopMenu()
    {
        ClearShopMenu();

        foreach (ShipOwned ship in _shipsSO.Ships)
        {
            if (!ship.Owned)
            {
                GameObject slotInstance = Instantiate(_slotPrefab, _slotParent);

                slotInstance.transform.GetComponent<BuyShipSlot>().SetupSlot(ship);
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