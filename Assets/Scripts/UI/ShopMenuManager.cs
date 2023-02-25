using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _shopCanvas;
	[SerializeField]
	private GameObject _setupCanvas;

    private void OnEnable()
    {
		_shopCanvas.SetActive(true);
		_setupCanvas.SetActive(false);
	}

    public void StopShopping()
	{
		// Open Setup Canvas (where you choose which ship to use, outfit it, etc.). 
		_shopCanvas.SetActive(false);
		_setupCanvas.SetActive(true);
	}
}