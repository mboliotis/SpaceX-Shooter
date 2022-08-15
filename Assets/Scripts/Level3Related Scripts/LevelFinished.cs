using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour
{
    [SerializeField]
    GameObject mars;

    bool repeatLock;
    // Start is called before the first frame update
    void Start()
    {
        repeatLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mars.transform.localScale.x >= 3 && repeatLock == false)
        {
            // if we exceed some possitions the mission failed as we missed the planet XD
            Vector2 marsPos = mars.GetComponent<Rigidbody2D>().position;
            if (marsPos.x <= -0.24f  && marsPos.y <= -2.14f)
            {
                
                this.gameObject.GetComponent<GameManagerIO>().WriteToBuffer(MessageEnum.GAME_END);
                repeatLock = true;
            }
        }
    }
}
