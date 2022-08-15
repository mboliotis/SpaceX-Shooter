using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject mars;

    [SerializeField]
    GameObject missionFailed;

    bool repeatLock;
    // Start is called before the first frame update
    void Start()
    {
        repeatLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Depending on mars scale (in-game: how close we are to mars) 
        if (mars.transform.localScale.x > 2 && repeatLock == false)
        {
            // if we exceed some possitions the mission failed as we missed the planet XD
            Vector2 marsPos = mars.GetComponent<Rigidbody2D>().position;
            if (marsPos.x > 6f || marsPos.x < -6f || marsPos.y > 6f || marsPos.y < -6f)
            {
                DisplayMissionFailedPanel();
                this.gameObject.GetComponent<GameManagerIO>().WriteToBuffer(MessageEnum.MISSION_FAILED);
                repeatLock = true;
            }
        }
    }

    void DisplayMissionFailedPanel()
    {
        missionFailed.SetActive(true);
    }


}
