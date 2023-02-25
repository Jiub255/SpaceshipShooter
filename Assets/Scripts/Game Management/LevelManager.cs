using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bossPrefab;
    [SerializeField, Range(0f, 7f)]
    private float _lerpDuration = 3f;
    [SerializeField, Range(0f, 5f)]
    private float _waitDuration = 1f;
    [SerializeField, Range(1f, 120f)]
    private float _levelDuration = 30f;
    private float _timer;
    private Transform _player;
	private EnemySpawner _enemySpawner;
    private Vector3 _bossSpawnPosition;
    private Vector3 _bossStartPosition;
    private Vector3 _playerStartPosition;
    private bool _fightingBoss = false;

    private void Start()
    {
        _timer = _levelDuration;
        _player = FindObjectOfType<PlayerHealth>().transform;

        // EnemySpawner and LevelManager both on Game Manager child GO of The Singleton. 
        _enemySpawner = GetComponent<EnemySpawner>();

        Camera camera = Camera.main;
        float spawnY = camera.orthographicSize * 1.5f;
        float startY = camera.orthographicSize * 0.5f;
        float playerStartY = camera.orthographicSize * -0.5f;
        _bossSpawnPosition = new Vector3(0f, spawnY, 0f);
        _bossStartPosition = new Vector3(0f, startY, 0f);
        _playerStartPosition = new Vector3(0f, playerStartY, 0f);

    }

    private void Update()
    {
        if (!_fightingBoss)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _fightingBoss = true;
                _timer = _levelDuration;
                StartBossFight();
            }
        }
    }

    private void StartBossFight()
    {
        StartCoroutine(BossIntro());
    }

    private IEnumerator BossIntro()
    {
        _enemySpawner.enabled = false;

        // Either wait until all enemies are off screen (calculate from lowest speed enemy & Camera.main.orthographicSize), 
        // or don't disable player controls and let them fight while boss gets in position. 

        // Find the lowest speed of all currently active enemies. 
        EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
        float lowestSpeed = 4206980081134;
        if (enemyMovements.Length > 0)
        {
            foreach (EnemyMovement enemyMovement in enemyMovements)
            {
                if (enemyMovement.Speed < lowestSpeed)
                {
                    lowestSpeed = enemyMovement.Speed;
                }
            }
        }

        // Wait the time it takes for the slowest enemy to move across the screen completely. 
        // If no enemies are active, it's dividing by a huge number (4206980081134) so it's essentially a zero second wait. 
        yield return new WaitForSeconds((Camera.main.orthographicSize * 2.75f) / lowestSpeed);

        // Disable player controls. 
        S.I.IM.PC.Gameplay.Disable();

        // Instantiate boss. 
        GameObject bossInstance = Instantiate(_bossPrefab, _bossSpawnPosition, Quaternion.identity);

        // Disable boss shooting. 
        // TODO: Do this better once enemy structure is figured out. 
        bossInstance.transform.GetChild(0).GetComponentInChildren<EnemyShoot>().enabled = false;

        // Disable boss movement. 
        bossInstance.GetComponent<BossJamesMovement>().enabled = false;

        // Lerp boss into position from above top of screen
        float time = 0f; 
        Vector3 bossSpawnPosition = bossInstance.transform.position;
        Vector3 playerOriginalPosition = _player.position;
        while (time < _lerpDuration)
        {
            bossInstance.transform.position = Vector3.Lerp(
                bossSpawnPosition, 
                _bossStartPosition,
                time / _lerpDuration);

            _player.position = Vector3.Lerp(
                playerOriginalPosition, 
                _playerStartPosition,
                time / _lerpDuration);

            time += Time.deltaTime;
            yield return null;
        }
        bossInstance.transform.position = _bossStartPosition;

        // Wait a second for suspense/so you don't get thrown in. 
        yield return new WaitForSeconds(_waitDuration);

        // Reenable player controls. 
        S.I.IM.PC.Gameplay.Enable();

        // Reenable boss shooting. 
        bossInstance.transform.GetChild(0).GetComponentInChildren<EnemyShoot>().enabled = true;

        // Reenable boss movement. 
        bossInstance.GetComponent<BossJamesMovement>().enabled = true;
    }
}