using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGeneratorVol2 : MonoBehaviour
{

    [SerializeField]
    GameObject levelManager;

    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    float timeBetweenSpawn;


    bool scriptLock;

    bool spawnLock;
    // Start is called before the first frame update
    void Start()
    {
        levelManager.GetComponent<GameMaster>().OnGameReady += EnableScript;
        scriptLock = true;
        spawnLock = false;
    }

    public void EnableScript(EventReason evt)
    {
        if(evt == EventReason.GAME_START)
        {
            scriptLock = false;
        }
        else
        {
            scriptLock = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (scriptLock) return;

        if (!spawnLock)
        {
            GenerateAsteroid();
            spawnLock = true;
            StartCoroutine(CanSpawn());
        }
        
    }


    void GenerateAsteroid()
    {
        GameObject aster = Instantiate(asteroidPrefab);
        aster.transform.position = this.gameObject.transform.position;
    }

    IEnumerator CanSpawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        spawnLock = false;
    }

}
