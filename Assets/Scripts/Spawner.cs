using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The spawn timer is " + spawnTimer);
        spawnTimer = spawnTimer - Time.deltaTime;

        if (spawnTimer < 0) 
        {
            spawnLog();
            spawnTimer = 5;
        }
    }

    void spawnLog()
    {
        GameObject log = ObjectPool.instance.GetPooledLog();

        if (log != null ) 
        {
          log.transform.position = transform.position;
            log.SetActive(true);
        }
    }
}
