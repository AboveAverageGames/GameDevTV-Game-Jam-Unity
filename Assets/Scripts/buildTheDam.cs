using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildTheDam : MonoBehaviour
{
    public int logCount = 1;
    public GameObject[] damRow;
    public Transform[] damT;
    int value12 = 0;
    public GameManager GM;
    public GameObject Scene;
    public GameObject WaterMax;
    //float ScenePos = 0;
    int howManyLogs;
    public int logC = 0;
    //float speed = 0.000002f;

    //0.7 rise per wave
    //-2.2 start

    // Start is called before the first frame update
    void Start()
    {
        howManyLogs = GM.totalLogsNeededToCompleteDamLayer + GM.additionalLogsAllowedToBeSpawned;
        damT = gameObject.GetComponentsInChildren<Transform>();
        damRow = new GameObject[damT.Length];

        foreach (Transform trans in damT)
        {
            value12++;
            damRow.SetValue(trans.gameObject, value12 - 1);
        }
        value12 = 0;
        foreach (Transform trans in damT)
        {
            if (damRow[value12].tag != "Ignore" && damRow[value12].tag != "Dam") 
            {
                damRow[value12].SetActive(false);
            }
            value12++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        if (damRow[logCount].tag == "Ignore")
        {
            logCount++;
        }

        //Scene.transform.position = Vector3.MoveTowards(WaterMax.transform.position, WaterMax.transform.position , step);

        if (GM.waveCompleted == true)
        {
            howManyLogs = howManyLogs + 2;
        }
    }
}
// I'm tired.