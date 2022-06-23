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

    [SerializeField]
    GameObject backgroundMoving;

    [SerializeField]
    float speed;
     


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
            Disable();
            StartCoroutine(EnableSpawn());
        }

        // Disable asteroid generator when at the end of level
        if (backgroundMoving.GetComponent<MoveBG>().isStoped)
        {
            this.enabled = false;
        }

    }

    IEnumerator EnableSpawn()
    {
        yield return new WaitForSeconds(secondsBetweenSpawns);
        Enable();
         
    }
}
