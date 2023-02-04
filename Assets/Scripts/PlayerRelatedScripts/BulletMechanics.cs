using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{

    [SerializeField]
    float m_damage;

    [SerializeField]
    GameObject collisionSparks;

    [SerializeField]
    GameObject sparkPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
        Damage = m_damage;
        StartCoroutine(LifeSpan());
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    float Damage { set; get; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            
            col.gameObject.GetComponent<CommonEnemyInterface>().TakeDamage(this.Damage);
            GameObject sparks = Instantiate(collisionSparks);
            sparks.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
        }
        
        

    }

     

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(10f);

        if(this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        

    }

}
