using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour,IEnemy
{
    [SerializeField]
    GameObject asteroidPref; // asteroid prefab refference

    [SerializeField]
    GameObject instaceLoc; // where to set the location of the instace at spawn

    [SerializeField]
    float[] verticalAsteroidVelocityRange; 

    [SerializeField]
    float[] horizontalAsteroidVelocityRange;

    [SerializeField]
    float secondsBetweenSpawns;

    [SerializeField]
    GameObject gameManager;
    bool enableThisScript;
    bool spawn;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameMaster>().OnEndOfTutorial += EndOfTutorial; // subscribe to event: End of Tutorial
        enableThisScript = false;
        Enable();
    }

    void EndOfTutorial(GameObject sender)
    {
        this.enableThisScript = true;
    }

    public void Disable()
    {
        this.spawn = false;
    }

    public  void Enable()
    {
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableThisScript)
        {
            return;
        }
        if (spawn)
        {
            GameObject aster = Instantiate(asteroidPref, instaceLoc.transform.position, instaceLoc.transform.rotation);

            float xvel = Random.Range(verticalAsteroidVelocityRange[0], verticalAsteroidVelocityRange[1]);
            float yvel = Random.Range(horizontalAsteroidVelocityRange[0], horizontalAsteroidVelocityRange[1]); 
            aster.GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, yvel);
            Disable();
            StartCoroutine(EnableSpawn());
        }
        

    }

    IEnumerator EnableSpawn()
    {
        yield return new WaitForSeconds(secondsBetweenSpawns);
        Enable();
         
    }
}
