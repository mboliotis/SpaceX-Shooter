using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpaceship : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePref;

    [SerializeField]
    GameObject shootPoint;

    [SerializeField]
    float speed;


    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot){
            
            GameObject bullet = Instantiate(projectilePref);
            bullet.transform.position = shootPoint.transform.position;
            
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            canShoot=false;
            StartCoroutine(EnableShooting());
        }
    }

    IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(0.15f);
        canShoot = true;
    }

}
