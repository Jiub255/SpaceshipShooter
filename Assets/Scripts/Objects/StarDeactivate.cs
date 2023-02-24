using UnityEngine;

public class StarDeactivate : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -_camera.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }
}