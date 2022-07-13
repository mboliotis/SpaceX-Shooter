using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    AudioSource backgroundAudio;

    [SerializeField]
    GameObject introPanel;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject outroPanel;
     

    [SerializeField]
    float musicStartTime;

    //================= Event Section ================= 
    /*
     * The game manager can fire events to inform other game objects.
     */
    public delegate void LevelManagmentEvents(EventReason fireReason); 

    public event LevelManagmentEvents OnGameReady; 
    //================= Event Section ================= 

    bool introMessageEnded;
    // Start is called before the first frame update
    void Start()
    { 
        backgroundAudio.Stop();
        introMessageEnded = false; 
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);// save player's progress 
    }

    


    // Update is called once per frame
    void Update()
    {
        
        // play background music
        if (introMessageEnded && !backgroundAudio.isPlaying)
        {
            backgroundAudio.time = musicStartTime;
            backgroundAudio.Play();
        }

    }

    

    /*
     * Interface for UI buttons at the intro panel
     */
    public void DisableIntroPanel()
    {
        introPanel.SetActive(false); 
        if (OnGameReady != null )
        {
            OnGameReady(EventReason.GAME_START);

        }
        introMessageEnded = true;
    }


    public void DisplayPauseMenu()
    {
        this.gameObject.GetComponent<PauseMenu>().ToggleMenu = true;
    }

    public void PlayerDied()
    {
         
        this.gameObject.GetComponent<PauseMenu>().PlayerDied = true; 
    }



    /*
     * Used to display some message at the end of the level
     */
    public void DisplayOutro()
    {
        outroPanel.SetActive(true);
        if (OnGameReady != null)
        {
            OnGameReady(EventReason.GAME_STOP);

        }
    }
}
