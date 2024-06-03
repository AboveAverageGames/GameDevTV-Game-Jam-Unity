using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Game manager stuuuff
    public GameManager gameManager;
    public buildTheDam BD;

    //Spawn timers
    public float spawnTimer;
    private float spawnTimerStored;

    //For Positoning Of items
    private float xAxisRandomSpawn;
    public float damWidthIncrease;

    //Float to decide random item to be spawned
    private float randomItemToBeSpawned;

    // Start is called before the first frame update
    void Start()
    {

        //Assigns GameManager script to gameManager
        gameManager = GameObject.Find("--- Game Manager ---").GetComponent<GameManager>();

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
            RandomSpawner();
            //Resets Spawn Timer
            spawnTimer = spawnTimerStored;
        }
    }

    //Gets a random location to spawn items
    public Vector3 randomPlace()
    {
        //Finds a random X position on the Dam (WHICH INCREASES WITH EACH WAVE)
        xAxisRandomSpawn = Random.Range((-10 - damWidthIncrease),(10 + damWidthIncrease));
        return new Vector3 (xAxisRandomSpawn, 0, 45);
        
    }


    //This chooses a random number between 1 and 3, and then Each value decides what item is spawned
    // 1 or 2: Log, 2:Food 3:Pollution
    void RandomSpawner()
    {
        randomItemToBeSpawned = Random.Range(1, 7);

        //50% chance for it to be log that is spawned
        if (randomItemToBeSpawned <= 3 && gameManager.canAnyMoreLogsBeSpawned)
        {
            spawnLog();
            gameManager.logsSpawnedThisLayer++;
        }
        else if (randomItemToBeSpawned == 4)
        {
            spawnFood();
        }
        else if (randomItemToBeSpawned >= 5)
        {
            spawnPollution();
        }
    }

    //Spawn Timer
    void SpawnTimer()
    {
        spawnTimer = spawnTimer - Time.deltaTime;
    }



    //--- Spawn stuff below ---
    void spawnLog()
    {
        GameObject log = ObjectPool.instance.GetPooledLog();
        BD.logC++;
        if (log != null ) 
        {
          log.transform.position = randomPlace();
          log.transform.localRotation = Quaternion.Euler(90, 0, -90);
            log.SetActive(true);
        }
    }

    void spawnFood()
    {
        GameObject food = ObjectPool.instance.GetPooledFood();

        if (food != null)
        {
            food.transform.position = randomPlace();
            food.SetActive(true);
        }
    }


    void spawnPollution()
    {
        GameObject pollution = ObjectPool.instance.GetPooledPollution();

        if (pollution != null)
        {
            pollution.transform.position = randomPlace();
            pollution.SetActive(true);
        }
    }
}
