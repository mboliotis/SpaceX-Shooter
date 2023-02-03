using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMechanics : MonoBehaviour
{
    

    [SerializeField]
    float timeAlive;  // the lifespan of the asteroid in seconds

    [SerializeField]
    GameObject asteroidExplosionParticleSystem; // asteroid explosion-effect particles

    GameObject gameManager;
    
    bool enableThisScript;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        //gameManager.GetComponent<GameMaster>().OnGameReady += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = true; 
        StartCoroutine(LifeSpan());
    }


    

    // Update is called once per frame
    void Update()
    {

        if (!enableThisScript)
        {
            return;
        }


        if (this.gameObject.GetComponent<CommonEnemyInterface>().HitPoints <= 0)
        {
            
            GameObject asterPartSys = Instantiate(asteroidExplosionParticleSystem);
            asterPartSys.transform.position = this.gameObject.transform.position;
            

            Destroy(this.gameObject);
        }
          
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictDamageToPlayer(collision.gameObject);
        }
    }


    /*
     *  This function is responsible for inflict damage to the player.
     *  Then it will instantiate the asteroid explosion effect particle system and destroy this asteroid gameobject
     */
    void InflictDamageToPlayer(GameObject p)
    {
        p.GetComponent<SpaceshipMechanics>().TakeDamage();
        GameObject asterPartSys = Instantiate(asteroidExplosionParticleSystem);
        asterPartSys.transform.position = this.gameObject.transform.position;
         

        Destroy(this.gameObject);
    }


    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(timeAlive);

        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }


    }


    //=============== Useless Functions (for the time being) ============================

    /*
     * This Method is responsible for collision detection.
     * For the time being is not used but reserved as legacy for future need.
     */
    void CheckCol()
    {
        Vector2 point = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        float radius = 1f; 
        Collider2D[] col = Physics2D.OverlapCircleAll(point, radius);
        if (col.Length > 0)
        {
            foreach (Collider2D element in col)
            {
                if (element.gameObject.CompareTag("Player"))
                {
                    if(element.gameObject.GetComponent<SpaceshipMechanics>() != null)
                    {
                        element.gameObject.GetComponent<SpaceshipMechanics>().TakeDamage();
                    }
                    
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
        
    }
    // maybe deprecated (must check!)
    void EndOfTutorial(EventReason sender)
    {
        if (sender == EventReason.GAME_START)
        {
            this.enableThisScript = true;
            Debug.Log("this workds");
        }
        else
        {
            this.enableThisScript = false;
        }

    }

    
}
