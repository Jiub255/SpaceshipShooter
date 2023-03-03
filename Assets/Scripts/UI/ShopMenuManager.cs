using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuManager : MonoBehaviour
{
	[SerializeField]
	private IntSO _levelIndexSO;
	[SerializeField, Header("Canvases")]
	private GameObject _shopShipsCanvas;
	[SerializeField]
	private GameObject _shopWeaponsCanvas;
	[SerializeField]
	private GameObject _chooseShipCanvas;
	[SerializeField]
	private GameObject _outfitShipCanvas;

    private void OnEnable()
    {
		GoToShopShipsMenu();
	}

	public void GoToShopShipsMenu()
    {
		_shopShipsCanvas.SetActive(true);
		_shopWeaponsCanvas.SetActive(false);
		_chooseShipCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(false);
    }

	public void GoToShopWeaponsMenu()
    {
		_shopShipsCanvas.SetActive(false);
		_shopWeaponsCanvas.SetActive(true);
		_chooseShipCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(false);
	}

	public void GoToShipSelection()
	{
		_shopShipsCanvas.SetActive(false);
		_shopWeaponsCanvas.SetActive(false);
		_chooseShipCanvas.SetActive(true);
		_outfitShipCanvas.SetActive(false);
	}

	public void GoToOutfitShip()
    {
		_shopShipsCanvas.SetActive(false);
		_shopWeaponsCanvas.SetActive(false);
		_chooseShipCanvas.SetActive(false);
		_outfitShipCanvas.SetActive(true);
    }

    public void StartNextLevel()
    {
		SceneManager.LoadScene(_levelIndexSO.Value);
    }
}