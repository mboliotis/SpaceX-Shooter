using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject continueButton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            continueButton.SetActive(true);
        }
    }

    private void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }


}
