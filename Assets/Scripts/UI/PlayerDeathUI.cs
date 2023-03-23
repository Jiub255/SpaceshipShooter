using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathUI : MonoBehaviour
{
	[SerializeField]
	private GameObject _playerDeathCanvas;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += OpenDeathCanvas;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= OpenDeathCanvas;
    }

    private void OpenDeathCanvas()
    {
        _playerDeathCanvas.SetActive(true);
    }

    // Called by death canvas button. 
    public void EndRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}