using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text enemyCountText;
    public TMP_Text difficultyText;

    void Start()
    {
        if(_GM.gameState == GameState.Playing)
        {
            UpdateScore(0);
            UpdateEnemyCount(0);
        }
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateTimer(float _timer)
    {
        timerText.text = "Time Remaining: " + _timer.ToString("F2");

        if (_timer < 10f)
            timerText.color = Color.red;
        else
            timerText.color = Color.white;
        if (_timer <= 0)
            Time.timeScale = 0;
    }

    public void UpdateEnemyCount(int _count)
    {
        enemyCountText.text = "Enemies: " + _count;
    }

    public void UpdateDifficulty(Difficulty _difficulty)
    {
        difficultyText.text = "Difficulty: " + _difficulty.ToString();
    }
}
