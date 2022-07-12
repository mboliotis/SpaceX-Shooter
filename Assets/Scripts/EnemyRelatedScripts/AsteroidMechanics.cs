using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMechanics : MonoBehaviour
{
    

    [SerializeField]
    float timeAlive;

    [SerializeField]
    GameObject asteroidExplosionParticleSystem;

    GameObject gameManager;
    bool enableThisScript;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false; 
        StartCoroutine(LifeSpan());
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
        if (this.gameObject.GetComponent<CommonEnemyInterface>().HitPoints <= 0)
        {
            GameObject asterPartSys = Instantiate(asteroidExplosionParticleSystem);
            asterPartSys.transform.position = this.gameObject.transform.position;
            

            Destroy(this.gameObject);
        }


        gameObject.transform.Rotate(0, 0, 180*Time.deltaTime);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictDamageToPlayer(collision.gameObject);
        }
    }

    void InflictDamageToPlayer(GameObject p)
    {
        p.GetComponent<SpaceshipMechanics>().TakeDamage();
        GameObject asterPartSys = Instantiate(asteroidExplosionParticleSystem);
        asterPartSys.transform.position = this.gameObject.transform.position;
         

        Destroy(this.gameObject);
    }


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
     

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(timeAlive);

        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }


    }
}
