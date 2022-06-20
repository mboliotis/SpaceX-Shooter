using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPref;

    [SerializeField]
    GameObject instaceLoc;


    bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
    }


    

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            GameObject aster = Instantiate(asteroidPref, instaceLoc.transform.position, instaceLoc.transform.rotation);

            float xvel = Random.Range(-10f, 10f);
            float yvel = Random.Range(-10f, -20f); 
            aster.GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, yvel);
            spawn = false;
            StartCoroutine(EnableSpawn());
        }
        

    }

    IEnumerator EnableSpawn()
    {
        yield return new WaitForSeconds(0.5f); 
        spawn = true;
         
    }
}
