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

    bool canShoot;


    [SerializeField]
    GameObject gameManager;
    bool enableThisScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false;
        shootSound.Stop();
        canShoot = true;
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
        if (Input.GetKey(KeyCode.Space) && canShoot){
            
            GameObject bullet = Instantiate(projectilePref);
            bullet.transform.position = shootPoint.transform.position;
            
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            shootSound.Play();
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
