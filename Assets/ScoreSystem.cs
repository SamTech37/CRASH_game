using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI scoreText, highscoreText;
    // Start is called before the first frame update


    void Update()
    {
        scoreText.text = "Wave "+ enemySpawner.waves.ToString();
        updateHighscore();
        updateHighScoreText();

    }
    public void updateHighscore()
    {
        PlayerPrefs.SetInt("Highscore", Mathf.Max(enemySpawner.waves, PlayerPrefs.GetInt("Highscore", 0)));
    }
    public void updateHighScoreText()
    {
        highscoreText.text = "Highest " + PlayerPrefs.GetInt("Highscore", 0);

    }
}
