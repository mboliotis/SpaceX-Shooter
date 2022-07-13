using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBackgroundInterface : MonoBehaviour
{
    [SerializeField]
    Vector2 moveDirestion;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Rigidbody2D rbody;
    [SerializeField]
    Vector2 stopTarget;

    /* 
     * Use this events to enable behaviours on other game objects in game.
     * These events fire only once!
     */
    public delegate void BackgroundEvents();
    public event BackgroundEvents OnLevelStart;
    public event BackgroundEvents OnLevelEnd;

    /*
     * Event locks to ensure that the events will fire only once
     */
    bool OnLevelStartLock;
    bool OnLevelEndLock;


    /*
     * Script lock to enable-disable the script.
     * This methodology is used if you want certain parts of the script not to run.
     */
    public bool ScriptLock
    {
        get;
        set;
    }


    // Start is called before the first frame update
    void Start()
    {
        OnLevelStartLock = false;
        OnLevelEndLock = false;
        ScriptLock = false;
    }

    // Update is called once per frame
    void Update()
    {


        // The code below may never run
        if (ScriptLock) return;
        if (!OnLevelStartLock)
        {
            if(OnLevelStart != null)
            {
                OnLevelStart();
            }
            
            OnLevelStartLock=true;
        }

        if(rbody.position.y <= stopTarget.y && !ScriptLock)
        {
            ScriptLock=true;
            if(OnLevelEnd != null)
            {
                OnLevelEnd();
            }
            OnLevelEndLock=true;
        }
        

    }

    private void FixedUpdate()
    {


        // The code below may never run
        if (ScriptLock) return;
        MoveTowardsDirection();
    }


    /*
     * Moves the background every Fixed Update towards the direction of "moveDirection"
     * by speed of "moveSpeed"
     */
    void MoveTowardsDirection()
    {
        rbody.MovePosition(rbody.position + moveDirestion*moveSpeed*Time.fixedDeltaTime);
    }


}
