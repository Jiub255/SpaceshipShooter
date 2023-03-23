using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _amountText;
	[SerializeField]
	private IntSO _coinsSO;
    [SerializeField]
    private Image _fillBarImage;

	private TemporaryLoot _temporaryLoot;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _temporaryLoot = FindObjectOfType<TemporaryLoot>();
        _playerHealth = _temporaryLoot.gameObject.GetComponent<PlayerHealth>();

        UpdateCoins();
        UpdateHealth();

        CoinCollector.OnCoinCollected += UpdateCoins;
        PlayerHealth.OnPlayerHurt += UpdateHealth;
    }

    private void OnDisable()
    {
        CoinCollector.OnCoinCollected -= UpdateCoins;
        PlayerHealth.OnPlayerHurt -= UpdateHealth;
    }

    private void UpdateCoins()
    {
		_amountText.text = (_coinsSO.Value + _temporaryLoot.Coins).ToString();
    }

    private void UpdateHealth()
    {
        _fillBarImage.fillAmount = (float)_playerHealth.CurrentHealth / (float)_playerHealth.MaxHealth;
    }
}