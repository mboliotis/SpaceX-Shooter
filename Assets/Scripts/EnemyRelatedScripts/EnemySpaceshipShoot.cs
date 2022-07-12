using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject shootPoint;

    [SerializeField]
    float timeBetweenAttacks;

    [SerializeField]
    float detectionRange;
    
    GameObject playerSpaceship;

    [SerializeField]
    AudioSource shootAudioSource;

    bool enemySpoted;
    bool cannonsFired;
    // Start is called before the first frame update
    void Start()
    {
        playerSpaceship = GameObject.FindGameObjectWithTag("Player");
        enemySpoted = false;
        cannonsFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpoted && !cannonsFired)
        {
            Shoot();
            cannonsFired = true;
            StartCoroutine(AttackSpeed());
        }

        if (Vector2.Distance(this.gameObject.transform.position, playerSpaceship.transform.position) < detectionRange)
        {
            enemySpoted = true;
        }

        if (Vector2.Distance(this.gameObject.transform.position, playerSpaceship.transform.position) > detectionRange)
        {
            enemySpoted = false;
        }

        if (Vector2.Distance(this.gameObject.transform.position, playerSpaceship.transform.position) < 0.5f)
        {
            Destroy(this.gameObject);
        }
    }

     

    void Shoot()
    {
        GameObject  bulletInstance = Instantiate(bulletPrefab);
        if(bulletInstance != null)
        {
            bulletInstance.transform.position = shootPoint.transform.position;
            bulletInstance.GetComponent<BulletMovement>().Direction = new Vector2(0, -1);
            bulletInstance.GetComponent<BulletMovement>().Speed = 10 + gameObject.GetComponent<EnemySpaceShipMovement>().Speed;
            shootAudioSource.Play();
        }
        else
        {
            Debug.Log("Error Instatiating Bullet!");
        }
        
    }

    IEnumerator AttackSpeed()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);

        cannonsFired = false;


    }

}
