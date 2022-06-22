using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    AudioSource backgroundAudio;

    [SerializeField]
    GameObject backgroundMoving;

    public delegate void EndOfTutorialEventHandler(GameObject sender);

    public event EndOfTutorialEventHandler OnEndOfTutorial;


    public bool finishedTutor;

    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio.Stop();
        finishedTutor = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(OnEndOfTutorial != null && finishedTutor)
        {
            OnEndOfTutorial(this.gameObject);
        }

        if (finishedTutor && !backgroundAudio.isPlaying)
        {
            backgroundAudio.time = 70f;
            backgroundAudio.Play();
        }

        if (backgroundMoving.GetComponent<MoveBG>().isStoped)
        {
            this.gameObject.GetComponent<AsteroidGenerator>().enabled = false;
        }

    }


}
