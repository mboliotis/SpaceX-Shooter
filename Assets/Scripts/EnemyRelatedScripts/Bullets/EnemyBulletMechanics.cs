using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMechanics : MonoBehaviour
{

    [SerializeField]
    float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
