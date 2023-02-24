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
	[SerializeField]
	private GameObject _cleanUp;

	private Camera _camera;

	// _camera.orthographicSize is half screen height.
	// _camera.aspect is screen width/height. 
	// So, _camera.orthographicSize * _camera.aspect is half screen width. 
    private void Start()
    {
		_camera = Camera.main;

		_top.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f)) + new Vector3(0f, 1f, 0f);
		_top.transform.localScale = new Vector3(_camera.orthographicSize * _camera.aspect * 2f, 2f, 1f);

		_bottom.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)) + new Vector3(0f, -1f, 0f);
		_bottom.transform.localScale = new Vector3(_camera.orthographicSize * _camera.aspect * 2f, 2f, 1f);
		
		_left.transform.position = _camera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)) + new Vector3(-1f, 0f, 0f);
		_left.transform.localScale = new Vector3(2f, _camera.orthographicSize * 2f, 1f);
		
		_right.transform.position = _camera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)) + new Vector3(1f, 0f, 0f);
		_right.transform.localScale = new Vector3(2f, _camera.orthographicSize * 2f, 1f);

		_cleanUp.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 0f));
		_cleanUp.transform.localScale = new Vector3(_camera.orthographicSize * _camera.aspect * 4f, 2f, 1f);
	}
}