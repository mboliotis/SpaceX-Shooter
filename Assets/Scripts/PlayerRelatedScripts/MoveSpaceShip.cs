using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceShip : MonoBehaviour
{

    [SerializeField]
    float manouverSpeed;

    [SerializeField]
    float lefttBoundary;

    [SerializeField]
    float rightBoundary;

    [SerializeField]
    float topBoundary;

    [SerializeField]
    float bottomBoundary;

    [SerializeField]
    GameObject gameManager;
    bool enableThisScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnGameReady += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false;
    }

    void EndOfTutorial(EventReason sender)
    {
        if(sender == EventReason.GAME_START)
        {
            this.enableThisScript = true;
        }
        else
        {
            this.enableThisScript = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!enableThisScript)
        {
            return;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(gameObject.transform.position.x < rightBoundary)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + manouverSpeed*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(gameObject.transform.position.x > lefttBoundary)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - manouverSpeed*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gameObject.transform.position.y < topBoundary)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + manouverSpeed * Time.deltaTime, gameObject.transform.position.z);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (gameObject.transform.position.y > bottomBoundary)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - manouverSpeed * Time.deltaTime, gameObject.transform.position.z);
        }

    }
}
