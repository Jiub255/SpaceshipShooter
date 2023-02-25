using System.Collections.Generic;
using UnityEngine;

public class BossJamesMovement : MonoBehaviour
{
	[SerializeField]
	private float _speed = 5f;
	private Rigidbody2D _rb;

    private List<Vector2> _waypoints = new List<Vector2>();
    private int _index;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        float xMax = Camera.main.orthographicSize * Camera.main.aspect * 0.5f;
        float xMin = -xMax;
        float y = Camera.main.orthographicSize * 0.5f;

        _waypoints.Add(new Vector3(xMin, y));
        _waypoints.Add(new Vector3(xMax, y));
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_rb.position, _waypoints[_index]) > 0.1f)
        {
            Vector3 desiredPosition = _rb.position + ((_waypoints[_index] - _rb.position).normalized * _speed * Time.fixedDeltaTime);
            _rb.MovePosition(desiredPosition);
        }
        else
        {
            _rb.MovePosition(_waypoints[_index]);
            _index++;
            if (_index >= _waypoints.Count)
            {
                _index = 0;
            }
        }
    }
}