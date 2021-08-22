using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject uiGameOverWindow;
    public GameObject uiPauseWindow;

    public static bool gameIsPaused;

    private Player myPlayer; 
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            uiPauseWindow.SetActive(!uiPauseWindow.activeSelf);
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0;
            myPlayer.playerCanMove = false;
        }
        else
        {
            Time.timeScale = 1;
            myPlayer.playerCanMove = true;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
