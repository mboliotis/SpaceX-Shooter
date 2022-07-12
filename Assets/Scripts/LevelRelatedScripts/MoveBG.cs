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

    [SerializeField]
    GameObject[] mustDisable;

    [SerializeField]
    GameObject[] mustEnable;


    [SerializeField]
    GameObject gameManager;
    bool enableThisScript;

    public delegate void LevelEventHandler(GameObject obj);
    public event LevelEventHandler OnLevelEnd;
    public event LevelEventHandler OnLevelStart;

    bool firedOnLevelEnd;
    bool firedOnLevelStart;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false;
        isStoped = false;
        firedOnLevelEnd = false;
        firedOnLevelStart = false;
    }

    void EndOfTutorial(GameObject sender)
    {
         
        this.enableThisScript = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableThisScript)
        {
            return;
        }
        if (bg.transform.position.y > stop)
        {
            float move_y_axis = bg.transform.position.y - speed * Time.deltaTime;
            bg.transform.position = new Vector3(bg.transform.position.x, move_y_axis, bg.transform.position.z);
            
        }
        else
        {
            isStoped = true;
            
            if(OnLevelEnd != null && !firedOnLevelEnd)
            {
                OnLevelEnd(this.gameObject);
                firedOnLevelEnd = true;
            }

        }

        
    }


     

    public bool isStoped
    {
        get;
        set;
    }

}
