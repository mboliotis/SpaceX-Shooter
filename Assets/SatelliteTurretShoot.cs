using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteTurretShoot : MonoBehaviour
{
     
    [SerializeField]
    float reloadTime;

    [SerializeField]
    Vector2 cannonDirection; //  the current direction
    [SerializeField]
    GameObject cannonRef;

    Rigidbody2D cannonRigitB;

    [SerializeField]
    GameObject bulletPref;
    [SerializeField]
    GameObject shootPoint;

    [SerializeField]
    GameObject levelManager;

    bool isReloading;
    bool coroutineLock;

    GameObject player;


    bool lockNow;
    // Start is called before the first frame update
    void Start()
    {
        coroutineLock = false;
        player = GameObject.FindGameObjectWithTag("Player");
        lockNow = false;
        cannonRigitB = cannonRef.GetComponent<Rigidbody2D>();
        CalculateDirection();
        lockNow = true;
        levelManager.GetComponent<GameMaster>().OnGameReady += UnPause;
    }

    void UnPause(EventReason evt)
    {
        if(evt == EventReason.GAME_START)
        {
            lockNow = false;
        }
        else
        {
            lockNow=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lockNow) return;
        if (isReloading && !coroutineLock)
        {
             
            StartCoroutine(Reload());
            coroutineLock = true;
        }
         
        
        CalculateDirection();

        Vector2 playerDirection = PlayerDirection();
        if (ShallShoot(playerDirection))
        {
            if (!isReloading)
            {
                Shoot();
            }
            
        }
        else
        {
            RotateCannon();
        }

        
        if(cannonRigitB.rotation == 360)
        {
            cannonRigitB.rotation = 0;
        }

    }

    /*
     * Check if the cannon is pointing at the player
     */
    bool ShallShoot(Vector2 playerDirection)
    {
        float OFFSET = 0.05f;
        
        if(cannonDirection.x <= playerDirection.x + OFFSET && cannonDirection.x >= playerDirection.x - OFFSET)
        {
            if (cannonDirection.y <= playerDirection.y + OFFSET && cannonDirection.y >= playerDirection.y - OFFSET)
            {
                return true;
            }
        }
        
        return false;
    }

    /*
     * Return a normalized vector pointing at the direction of the player.
     * Satellite POV
     */
    Vector2 PlayerDirection()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        Vector2 playerCannonDistance = new Vector2(playerX - cannonRigitB.position.x , playerY - cannonRigitB.position.y );
        playerCannonDistance.Normalize();  
        return playerCannonDistance;
    }
     

    void Shoot()
    { 
        GameObject bul = Instantiate(bulletPref);
        bul.transform.parent = cannonRef.transform;
        bul.transform.position = shootPoint.transform.position;
        bul.transform.rotation = Quaternion.Euler(new Vector3(0, 0, cannonRigitB.rotation));
        bul.GetComponent<BulletMovement>().Speed = 10f;
        bul.GetComponent<BulletMovement>().Direction = cannonDirection;
        isReloading = true;
    }


    /*
     * Calculate the direction of the cannon while it rotates
     */
    void CalculateDirection()
    {
        float NINTY_DEGREE_TO_RAD = Mathf.PI / 2; // initial phase based on the direction of the sprite
        float cannonRotationToRads = Mathf.Deg2Rad*cannonRigitB.rotation; // conver cannon angle to rads
        cannonDirection = new Vector2(Mathf.Cos(cannonRotationToRads - NINTY_DEGREE_TO_RAD) , Mathf.Sin(cannonRotationToRads - NINTY_DEGREE_TO_RAD)); 
    }

    void RotateCannon()
    {
        cannonRigitB.rotation += 1;
        cannonRigitB.rotation = Mathf.CeilToInt(cannonRigitB.rotation);
    }

    IEnumerator Reload()
    {
        
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        coroutineLock = false;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(cannonRigitB.position, cannonRigitB.position + cannonDirection);
    }*/

}
