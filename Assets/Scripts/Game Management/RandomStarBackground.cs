using System.Collections.Generic;
using UnityEngine;

public class RandomStarBackground : MonoBehaviour
{
    // Puts stars randomly over a black background. 
    [SerializeField]
    private PoolTagSO _starPoolTag;
    [SerializeField, Range(0.1f, 10f)]
    private float _backgroundScrollSpeed = 1f;
    [SerializeField, Range(0, 100)] 
    private int _minNumberOfStars = 50;
    [SerializeField, Range(101, 1000)] 
    private int _maxNumberOfStars = 200;
    [SerializeField, Range(0.01f, 1f)]
    private float _maxStarSize = 0.3f;
    [SerializeField]
    private List<Color> _colors = new List<Color>{
        new Color(137f/255f, 95f/255f, 95f/255f), // Red 
        new Color(146f/255f, 147f/255f, 100f/255f), // Yellow 
        new Color(108f/255f, 152f/255f, 156f/255f), // Blue 
        new Color(124f/255f, 81f/255f, 142f/255f), // Purple 
        new Color(84f/255f, 140f/255f, 90f/255f), // Green 
        new Color(255f/255f, 255f/255f, 255f/255f), // White 
        new Color(255f/255f, 255f/255f, 255f/255f), // White 
    };

    private Vector3[] _starPositions;
    private float _screenHeight;
    // Timer made to last long enough to cross a full background. 
    private float _timer;
    private int _howManyTimesStarsMade = 0;
    private Camera _camera;
    private ObjectPool _objectPool;
    private Transform _transform;

    private void Start()
    {
        _camera = Camera.main;
        _screenHeight = _camera.orthographicSize * 2;
        _objectPool = S.I.ObjectPool;
        _transform = transform;
        MakeStars(true);
    }

    private void Update()
    {
        float y = (_transform.position + Vector3.down * _backgroundScrollSpeed * Time.deltaTime).y;
        _transform.position = new Vector3(_transform.position.x, y, 0f);

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _screenHeight / _backgroundScrollSpeed;
            MakeStars();
        }
    }

    private void MakeStars(bool firstTime = false)
    {
        int numberOfStars = HowManyStars();
        _starPositions = new Vector3[numberOfStars];
        GenerateStarPositions(numberOfStars, firstTime);
        InitializeStars();
        _howManyTimesStarsMade++;
    }

    // Pick random number of stars.
    private int HowManyStars()
    {
        return Random.Range(_minNumberOfStars, _maxNumberOfStars);
    }

    // Randomly choose the stars' positions.
    private void GenerateStarPositions(int numberOfStars, bool firstTime)
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            GenerateStarPosition(i, firstTime);
        }
    }

    private void GenerateStarPosition(int starIndex, bool firstTime)
    {
        float offset = _screenHeight;
        if (firstTime)
        {
            offset = 0f;
        }
        // Sets the star one _screenHeight above currently visible screen. 
        float x = Random.Range(-_camera.orthographicSize * _camera.aspect, _camera.orthographicSize * _camera.aspect);
        float y = Random.Range(-_camera.orthographicSize, _camera.orthographicSize) + offset;
        _starPositions[starIndex] = new Vector3(x, y, 0f);
    }

    // Activate stars from object pool. 
    private void InitializeStars()
    {
        foreach (Vector3 starPosition in _starPositions)
        {
            InitializeStar(starPosition);
        }
    }

    private void InitializeStar(Vector3 starPosition)
    {
        GameObject star = _objectPool.GetPooledObject(_starPoolTag);
        if (star != null)
        {
            // Set star's position from array of randomly generated positions. 
            star.transform.position = starPosition;

            // Randomize color and alpha.  
            Color randomColor = RandomColor();
            randomColor.a = Random.value;
            star.GetComponent<SpriteRenderer>().color = randomColor;

            // Randomize size. 
            float scaleFactor = Random.value * _maxStarSize;
            star.transform.localScale = Vector3.one * scaleFactor;

            // Set star's parent to transform. 
            star.transform.parent = transform;

            star.SetActive(true);
        }
    }

    private Color RandomColor()
    {
        int randomIndex = Random.Range(0, _colors.Count);

        return _colors[randomIndex];
    }
}