using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField]
    GameObject spaceshipExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.gameObject.GetComponent<CommonEnemyInterface>().HitPoints <= 0)
        {

            Death();
        }
        
        
    }

    void Death()
    {
        GameObject explos = Instantiate(spaceshipExplosion);
        explos.transform.position = this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Death();
            Destroy(this.gameObject);
        }
    }
}
