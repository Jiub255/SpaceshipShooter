using UnityEngine;

public class CameraBoundsSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject _top;
	[SerializeField]
	private GameObject _bottom;
	[SerializeField]
	private GameObject _left;
	[SerializeField]
	private GameObject _right;

	private Camera _camera;

	// _camera.orthographicSize is screen height.
	// _camera.aspect is screen width/height. 
	// So, _camera.orthographicSize * _camera.aspect is screen width. 
    private void Start()
    {
		_camera = Camera.main;

		_top.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 1f));
		_top.transform.localScale = new Vector3(_camera.orthographicSize * _camera.aspect * 2f, 0.1f, 1f);

		_bottom.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1f));
		_bottom.transform.localScale = new Vector3(_camera.orthographicSize * _camera.aspect * 2f, 0.1f, 1f);
		
		_left.transform.position = _camera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 1f));
		_left.transform.localScale = new Vector3(0.1f, _camera.orthographicSize * 2f, 1f);
		
		_right.transform.position = _camera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 1f));
		_right.transform.localScale = new Vector3(0.1f, _camera.orthographicSize * 2f, 1f);
	}
}