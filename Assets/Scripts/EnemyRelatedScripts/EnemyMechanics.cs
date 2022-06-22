using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{

    [SerializeField]
    float timeAlive;

    
    GameObject gameManager;
    bool enableThisScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false;
        HP = 20f;
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
        if (HP <= 0 )
        {
            Destroy(this.gameObject);
        }


        gameObject.transform.Rotate(0, 0, 180*Time.deltaTime);
        
    }

    void FixedUpdate()
    {
        if (!enableThisScript)
        {
            return;
        }
        CheckCol();
    }



    public float HP
    {
        get;
        set;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

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
                    element.gameObject.GetComponent<SpaceshipMechanics>().TakeDamage();
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, 1);
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
