using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnTimer;
    private float spawnTimerStored;


    private float randomItemToBeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        //Stores spawn timer
        spawnTimerStored = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Starts Spawn timer
        SpawnTimer();
        if (spawnTimer < 0)
        {
            
            //spawnLog();

            RandomSpawner();

            //Resets Spawn Timer
            spawnTimer = spawnTimerStored;
        }
    }




    //This chooses a random number between 1 and 3, and then Each value decides what item is spawned
    // 1 or 2: Log, 2:Food 3:Pollution
    void RandomSpawner()
    {
        randomItemToBeSpawned = Random.Range(1, 5);

        if (randomItemToBeSpawned <=2)
        {
            spawnLog();
            Debug.Log("Trying to spawn a damn log");
        }
        else if (randomItemToBeSpawned == 3)
        {
            spawnFood();
        }
        else if (randomItemToBeSpawned == 4)
        {
            spawnPollution();
        }
    }

    //Spawn Timer
    void SpawnTimer()
    {
        spawnTimer = spawnTimer - Time.deltaTime;
    }


    void spawnLog()
    {
        GameObject log = ObjectPool.instance.GetPooledLog();

        if (log != null ) 
        {
          log.transform.position = transform.position;
          log.transform.localRotation = Quaternion.Euler(90, 0, -90);
            log.SetActive(true);
        }
    }

    void spawnFood()
    {
        GameObject food = ObjectPool.instance.GetPooledFood();

        if (food != null)
        {
            food.transform.position = transform.position;
            food.SetActive(true);
        }
    }


    void spawnPollution()
    {
        GameObject pollution = ObjectPool.instance.GetPooledPollution();

        if (pollution != null)
        {
            pollution.transform.position = transform.position;
            pollution.SetActive(true);
        }
    }
}
