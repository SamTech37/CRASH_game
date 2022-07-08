using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameover;
    public GameObject joystick;
    public static bool isPaused = false;
    void Start()
    {
        menu.SetActive(false);
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        menu.SetActive(true);
        joystick.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void EndGame()
    {
        gameover.SetActive(true);
        joystick.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Respawn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
