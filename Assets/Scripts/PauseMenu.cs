using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;


    bool toggleMenu;

    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        toggleMenu = false;
        isDead = false;
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isDead)
        {
            toggleMenu = !toggleMenu;
            
        }

        if (toggleMenu || isDead)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }

    }

    void ShowMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
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
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
