using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    [SerializeField] private float _maxRunSpeed = 27f;
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _speedAdd = 1.5f;
    [SerializeField] private float _difficultyIncreaseTime = 10f;
    [SerializeField] private float _nextDifficultyTimeAdd = 7f;
    private float _timeCounter;
    private bool _limitReached = false;
    private float _speed;
    ChunkSpawnerManager chunkSpawnerManager;
    private void Awake()
    {
        _speed = _startSpeed;
        chunkSpawnerManager = GetComponent<ChunkSpawnerManager>();
        chunkSpawnerManager.ChangeRunSpeed(_speed);
    }

    private void Update()
    {
        if (_limitReached) return;
        _timeCounter += Time.deltaTime;
        if (_timeCounter > _difficultyIncreaseTime)
        {
            _timeCounter = 0;
            _difficultyIncreaseTime += _nextDifficultyTimeAdd;
            _speed += _speedAdd;
            float newSpeed = Mathf.Min(_maxRunSpeed, _speed);
            if (newSpeed == _maxRunSpeed)
                _limitReached = true;
            chunkSpawnerManager.ChangeRunSpeed(newSpeed);
        }
    }
}
