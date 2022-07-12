using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class EnemySpaceShipMovement : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rigit;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject gameManager;

    bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += GamePause;
        gamePaused = true;
    }

    void GamePause(GameObject sender)
    {
        
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
         
        
         
    }

    private void FixedUpdate()
    {
        if (!gamePaused)
        {
            rigit.MovePosition(rigit.position + new Vector2(0, -speed * Time.fixedDeltaTime));
        }
       
    }


    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }


}
