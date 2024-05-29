using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    [SerializeField] private GameObject logPrefab;
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
        LogPool();
        PollutionPool();
        FoodPool();
    }

    void LogPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(logPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void PollutionPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(pollutionPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void FoodPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(foodPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
