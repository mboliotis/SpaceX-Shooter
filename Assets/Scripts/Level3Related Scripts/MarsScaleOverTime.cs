using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsScaleOverTime : MonoBehaviour
{
    [SerializeField]
    float scaleFactor;

    [SerializeField]
    GameObject gameManager;


    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        gameManager.GetComponent<GameMaster>().OnGameReady += GameManagerEvent;
    }
    void  GameManagerEvent(EventReason fireReason)
    {
        if(fireReason == EventReason.GAME_START)
        {
            isPaused=false;
            
        }
        else
        {
            
            isPaused = true;
        } 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPaused) return;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale + new Vector3(scaleFactor*Time.fixedDeltaTime, scaleFactor * Time.fixedDeltaTime, 0);
    }
}
