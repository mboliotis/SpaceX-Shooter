using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody2D rBody;

    enum MoveDirestion { 
        right,
        left,
        up,
        down
    };

    MoveDirestion moveDir;

    [SerializeField]
    GameObject gameManager;


    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        moveDir = new MoveDirestion();
        isPaused = true;
        gameManager.GetComponent<GameMaster>().OnGameReady += GameManagerEvent;
    }

    void GameManagerEvent(EventReason fireReason)
    {
        if (fireReason == EventReason.GAME_START)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir = MoveDirestion.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir = MoveDirestion.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir = MoveDirestion.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir = MoveDirestion.down;
        }
    }

    private void FixedUpdate()
    {
        if (isPaused) return;
        Move(moveDir);
    }

    private void Move(MoveDirestion dir)
    {
        if(dir == MoveDirestion.right)
        {
            rBody.MovePosition(rBody.position - new Vector2(speed * Time.fixedDeltaTime, 0));
            
        }

        if (dir == MoveDirestion.left)
        {
            rBody.MovePosition(rBody.position + new Vector2(speed * Time.fixedDeltaTime, 0));
        }

        if (dir == MoveDirestion.up)
        {
            rBody.MovePosition(rBody.position - new Vector2(0, speed * Time.fixedDeltaTime));
        }

        if (dir == MoveDirestion.down)
        {
            rBody.MovePosition(rBody.position + new Vector2(0, speed * Time.fixedDeltaTime));
            
        }
    }


}
