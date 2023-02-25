using UnityEngine;

public class PlayerShipInstantiator : MonoBehaviour
{
	[SerializeField]
	private CurrentShipSO _currentShipSO;

    private void Awake()
    {
        float y = Camera.main.orthographicSize * -0.5f;
        Vector3 startingPosition = new Vector3(0f, y, 0f);

        Instantiate(_currentShipSO.currentShipPrefab, startingPosition, Quaternion.identity);
    }
}