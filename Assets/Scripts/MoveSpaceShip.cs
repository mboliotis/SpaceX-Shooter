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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
