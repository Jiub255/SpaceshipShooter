using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _amountText;
	[SerializeField]
	private IntSO _coinsSO;

	private TemporaryLoot _temporaryLoot;

    private void Start()
    {
        _temporaryLoot = FindObjectOfType<TemporaryLoot>();

        Coin.OnCoinCollected += UpdateHUD;

        UpdateHUD();
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateHUD;
    }

    public void UpdateHUD()
    {
		_amountText.text = (_coinsSO.Value + _temporaryLoot.Coins).ToString();
    }
}