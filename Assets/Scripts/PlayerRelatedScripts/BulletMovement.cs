using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField]
    Vector2 direction;

    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D rigBody;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity.x = direction.x * speed * Time.fixedDeltaTime;
        velocity.y = direction.y * speed * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigBody.MovePosition(new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y));
    }
}
