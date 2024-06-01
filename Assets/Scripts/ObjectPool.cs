using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> pooledLogs = new List<GameObject>();

    private List<GameObject> pooledFood = new List<GameObject>();

    private List<GameObject> pooledPollution = new List<GameObject>();

    private int amountToPool = 15;

    [SerializeField] private GameObject logPrefab1;
    [SerializeField] private GameObject logPrefab2;
    [SerializeField] private GameObject logPrefab3;
    [SerializeField] private GameObject pollutionPrefab;
    [SerializeField] private GameObject foodPrefab;


    private void Awake()
    {
        //If there is no singleton then make this the one that is accessible
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Pools 3 different Prefabs Of logs
        LogPool1();
        LogPool2();
        LogPool3();

        PollutionPool();
        FoodPool();
    }

    //Log Object pooling here
    void LogPool1()
    {
        for (int i = 0; i < amountToPool / 3; i++)
        {
            GameObject obj = Instantiate(logPrefab1);
            obj.SetActive(false);
            pooledLogs.Add(obj);
        }
    }

    void LogPool2()
    {
        for (int i = 0; i < amountToPool / 3; i++)
        {
            GameObject obj = Instantiate(logPrefab2);
            obj.SetActive(false);
            pooledLogs.Add(obj);
        }
    }

    void LogPool3()
    {
        for (int i = 0; i < amountToPool / 3; i++)
        {
            GameObject obj = Instantiate(logPrefab3);
            obj.SetActive(false);
            pooledLogs.Add(obj);
        }
    }

    public GameObject GetPooledLog()
    {
        for (int i = 0; i < pooledLogs.Count; i++)
        {
            if (!pooledLogs[i].gameObject.activeInHierarchy)
            {
                return pooledLogs[i];
               
            }
        }
        Debug.Log("No logs here sir");
        return null;
    }

    //Pollution Object Pooling here

    void PollutionPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(pollutionPrefab);
            obj.SetActive(false);
            pooledPollution.Add(obj);
        }
    }

    public GameObject GetPooledPollution()
    {
        for (int i = 0; i < pooledPollution.Count; i++)
        {
            if (!pooledPollution[i].gameObject.activeInHierarchy)
            {
                return pooledPollution[i];
            }
        }
        return null;
    }


    //Food Object Pooling Right Here
    void FoodPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(foodPrefab);
            obj.SetActive(false);
            pooledFood.Add(obj);
        }
    }

    public GameObject GetPooledFood()
    {
        for (int i = 0; i < pooledFood.Count; i++)
        {
            if (!pooledFood[i].gameObject.activeInHierarchy)
            {
                return pooledFood[i];
            }
        }
        return null;
    }

}
