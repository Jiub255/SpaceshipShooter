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

        CoinCollector.OnCoinCollected += UpdateHUD;

        UpdateHUD();
    }

    private void OnDisable()
    {
        CoinCollector.OnCoinCollected -= UpdateHUD;
    }

    public void UpdateHUD()
    {
		_amountText.text = (_coinsSO.Value + _temporaryLoot.Coins).ToString();
    }
}