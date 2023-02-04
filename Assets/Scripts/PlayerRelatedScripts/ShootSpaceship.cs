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

    [SerializeField]
    AudioSource shootSound;
     

    [SerializeField]
    int attacksPerSecond;

    float timeBetweenAttacks;
     

    [SerializeField]
    int maxAmmo;

    [SerializeField]
    float reloadTime; //in seconds

    [SerializeField]
    GameObject gameManager; //optional (legacy)
     

    bool enableThisScript;
    bool canShoot;
    bool reloadStarted;
    int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnGameReady += EndOfTutorial; // subscribe to event: End of Tutorial
        
       
        enableThisScript = false;
        shootSound.Stop();
        canShoot = true;
        currentAmmo = maxAmmo;
        timeBetweenAttacks = (float)1000/ (attacksPerSecond *1000);
        reloadStarted = false;
    }

    void EndOfTutorial(EventReason sender)
    {
        if(sender == EventReason.GAME_START)
        {
            this.enableThisScript = true;
        }
        else
        {
            this.enableThisScript = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableThisScript)
        {
            return;
        }

        if(currentAmmo <= 0 && !reloadStarted)
        {
            
            StopAllCoroutines();
            canShoot = false;
            reloadStarted = true;
            StartCoroutine(Reload());
        }
        else
        {
             
            if (Input.GetKey(KeyCode.Space) && canShoot)
            {
                canShoot = false;
                Shoot();
                StartCoroutine(EnableShooting());
                

            }
            
            
        }
        
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePref);
        bullet.transform.position = shootPoint.transform.position;
        
        shootSound.Play();

        currentAmmo -= 1;
        
    }

    IEnumerator EnableShooting()
    {
        
        yield return new WaitForSeconds(timeBetweenAttacks);

        if (currentAmmo > 0 )
        {
            canShoot = true;
        }
        
    }


    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime); 
        currentAmmo = maxAmmo;
        canShoot = true;
        reloadStarted = false;
    }

    public int GetCurrentAmmo()
    {
        return this.currentAmmo;
    }

}
