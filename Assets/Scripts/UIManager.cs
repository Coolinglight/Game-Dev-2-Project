using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text timerText;

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
}
