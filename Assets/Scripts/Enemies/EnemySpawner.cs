using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyChance
{
    public PoolTagSO EnemyPoolTag;
	public int Odds;
}

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private List<EnemyChance> _enemyChances = new List<EnemyChance>();
	[SerializeField]
	private float _minTimeBetweenSpawns = 0.5f;
	[SerializeField]
	private float _maxTimeBetweenSpawns = 2.5f;

	private float _timer;
    private int _totalProbability;
    private float _y;
    private float _xMin;
    private float _xMax;
    private ObjectPool _objectPool;

    private void Start()
    {
        _timer = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);

        CalculateTotalProbablility();

        Camera camera = Camera.main;
        _y = camera.orthographicSize + 5f;
        _xMax = camera.orthographicSize * camera.aspect;
        _xMin = -_xMax;

        _objectPool = S.I.ObjectPool;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
		if (_timer < 0)
        {
            _timer = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);

            // TODO: Draw from object pool instead. 
            GameObject enemyInstance = _objectPool.GetPooledObject(ChooseRandomEnemy());
            if (enemyInstance != null)
            {
                enemyInstance.transform.position = ChooseRandomSpawnPoint();
                enemyInstance.SetActive(true);
            }
        }
    }

    private Vector3 ChooseRandomSpawnPoint()
    {
        float x = Random.Range(_xMin, _xMax);

        return new Vector3(x, _y, 0f);
    }

    private PoolTagSO ChooseRandomEnemy()
    {
        int random = Random.Range(0, _totalProbability);
        int cumulativeProbability = 0;
        foreach (EnemyChance enemyChance in _enemyChances)
        {
            cumulativeProbability += enemyChance.Odds;
            if (random < cumulativeProbability)
            {
                return enemyChance.EnemyPoolTag;
            }
        }

        // Should never get here. 
        Debug.LogWarning("ChooseRandomEnemy should never return null. Some problem with the cumulative probabilities."); 
        return null;
    }

    private void CalculateTotalProbablility()
    {
        _totalProbability = 0;
        foreach (EnemyChance enemyChance in _enemyChances)
        {
            _totalProbability += enemyChance.Odds;
        }
    }
}