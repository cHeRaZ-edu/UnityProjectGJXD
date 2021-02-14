using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mGameManager : MonoBehaviour
{
    public bool isGame = false;
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject generalPanel;
    public GameObject optionsPanel;
    public GameObject gameOverPanel;

    public PlayerController player;

    public bool isPause = false;

    private bool isGamePause = false;
    private bool isGameResume = false;
    private bool isOptionsPanel = false;

    // Update is called once per frame
    void Update()
    {
        //if (isGame)
        //    InGame();
    }
    void InGame()
    {
        //if (player.health < 0)
        //{
        //    isPause = true;
        //    gameOverPanel.SetActive(true);
        //}
        //Options Panel
        if (isOptionsPanel)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PanelGeneral();
            }
            return;
        }
        //Event Pause
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;
        if (isPause)
        {
            isGameResume = false;
            if (!isGamePause)
            {
                isGamePause = true;
                SetGamePause(isGamePause);
            }
        }
        else
        {
            isGamePause = false;
            if (!isGameResume)
            {
                isGameResume = true;
                SetGamePause(isGamePause);
            }
        }

        if (isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    void PanelGeneral()
    {
        isOptionsPanel = false;
        generalPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    void SetGamePause(bool isPause)
    {
        pausePanel.SetActive(isPause);
        gamePanel.SetActive(!isPause);
    }
    //General Panel
    public void GameResume()
    {
        isPause = false;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OptionsPanel()
    {
        isOptionsPanel = true;
        generalPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void BackInitialMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    //OptionsPanel
    public void BackGeneralPanel()
    {
        PanelGeneral();
    }
    //Initial Menu
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
