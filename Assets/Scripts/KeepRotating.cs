using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotating : MonoBehaviour
{
    [SerializeField]
    float angularSpeed;

    [SerializeField]
    Rigidbody2D rigitB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        rigitB.rotation += angularSpeed ;
    }
}
