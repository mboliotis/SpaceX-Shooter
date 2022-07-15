using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    bool toggleMenu;
    bool playerDied;
    // Start is called before the first frame update
    void Start()
    {
        toggleMenu = false; 
        playerDied = false;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (playerDied)
        {
            ShowMenu();
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            toggleMenu = !toggleMenu;
            
        }

        if (toggleMenu )
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
            
        }



    }

    public bool PlayerDied
    {
        get { return playerDied; }  
        set { playerDied = value; }
    }

    public bool ToggleMenu
    {
        get { return toggleMenu; }
        set { toggleMenu = value; }
    }

    void ShowMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        
    }

    void HideMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
