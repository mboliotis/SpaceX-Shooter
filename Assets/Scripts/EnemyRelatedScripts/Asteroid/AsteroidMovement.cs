using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigBody;

    Vector2 velocity;

    private void Start()
    {
        velocity.x = Random.Range(-10f, 10f);
        velocity.y = Random.Range(-10f, -20f);
        velocity = velocity * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rigBody.MovePosition(new Vector2(transform.position.x + velocity.x,  transform.position.y + velocity.y) );
    }
}
