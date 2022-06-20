using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{

    [SerializeField]
    GameObject bg;

    [SerializeField]
    float stop;

    [SerializeField]
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {

        if (bg.transform.position.y > stop)
        {
            float move_y_axis = bg.transform.position.y - speed * Time.deltaTime;
            bg.transform.position = new Vector3(bg.transform.position.x, move_y_axis, bg.transform.position.z);
            
        }

        
    }
     

}
