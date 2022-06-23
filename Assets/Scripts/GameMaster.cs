using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    AudioSource backgroundAudio;

    [SerializeField]
    GameObject panelToDisable;

    public delegate void EndOfTutorialEventHandler(GameObject sender);

    public event EndOfTutorialEventHandler OnEndOfTutorial;


    bool finishedTutor;

    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio.Stop();
        finishedTutor = false;
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {

        
        // fire the edn of tutorial event to enable all game mechanics
        if(OnEndOfTutorial != null && finishedTutor)
        {
            OnEndOfTutorial(this.gameObject);
        }

        // play background music
        if (finishedTutor && !backgroundAudio.isPlaying)
        {
            backgroundAudio.time = 70f;
            backgroundAudio.Play();
        }

    }


    public void DisableTutorial()
    {
        panelToDisable.SetActive(false);
        finishedTutor = true;
    }

}
