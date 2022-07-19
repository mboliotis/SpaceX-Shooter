using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelBehaviour : MonoBehaviour
{

    [SerializeField]
    GameObject bground;

    // Start is called before the first frame update
    void Start()
    {
        bground.GetComponent<CommonBackgroundInterface>().OnLevelEnd += OnLevelEnd;
    }

    void OnLevelEnd()
    {
        this.gameObject.GetComponent<GameMaster>().DisplayOutro();
    }
     
}
