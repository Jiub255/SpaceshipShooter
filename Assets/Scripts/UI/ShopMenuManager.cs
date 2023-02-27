using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _shopCanvas;
	[SerializeField]
	private GameObject _chooseShipCanvas;
	[SerializeField]
	private GameObject _outfitShipCanvas;

    private void OnEnable()
    {
		_shopCanvas.SetActive(true);
		_chooseShipCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(false);
	}

    public void GoToShipSelection()
	{
		_shopCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(false);
		_chooseShipCanvas.SetActive(true);
	}

	public void GoToOutfitShip()
    {
		_shopCanvas.SetActive(false);
		_chooseShipCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(true);
    }
}