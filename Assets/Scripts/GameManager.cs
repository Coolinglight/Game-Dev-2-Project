using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Title, Playing, Paused, GameOver }
public enum Difficulty { Easy, Medium, Hard }

public class GameManager : Singleton<GameManager>
{
    public static event Action<Difficulty> OnDifficultyChanged = null;


    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplier = 1;
    public float maxTime = 60;
    float timer = 30;
    public int bonusTime = 5;
    
    void Start()
    {
        SetUp();
        OnDifficultyChanged?.Invoke(difficulty);
    }

    void Update()
    {
        if(gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, maxTime);
            _UI.UpdateTimer(timer);
        }
    }

    void SetUp()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                    break;
            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
        }

        if(gameState == GameState.Playing)
        {
            _UI.UpdateDifficulty(difficulty);
        }
        
    }

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    private void OnEnable()
    {
        Enemy.OnEnemyHit += OnEnemyHit;
        Enemy.OnEnemyDie += OnEnemyDie;

    }

    private void OnDisable()
    {
        Enemy.OnEnemyHit -= OnEnemyHit;
        Enemy.OnEnemyDie -= OnEnemyDie;
    }

    public void OnEnemyHit(GameObject _enemy)
    {
        AddScore(10);
    }

    public void OnEnemyDie(GameObject _enemy)
    {
        AddScore(100);
        AddTime(1);
    }

    public void AddTime(int _timer)
    {
        timer += _timer + bonusTime;
        _UI.UpdateTimer(timer);
    }
}
