using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeBotones : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Canvas pauseMenuUI;

    public GameObject tirador;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.enabled = false;
        tirador.GetComponent<ParticleManger>().Restart();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
