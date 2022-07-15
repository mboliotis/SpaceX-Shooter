using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyInterface : MonoBehaviour
{

    [SerializeField]
    float hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints <= 0)
        {
            Death();
            
        }
    }

    public float HitPoints
    {
        get { return hitPoints; }
        set { hitPoints = value; }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
    }

    void Death()
    { 
        Destroy(this.gameObject);
    }



}
