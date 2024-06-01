using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildTheDam : MonoBehaviour
{
    public int logCount = 1;
    public GameObject[] L12rows;
    public Transform[] L12T;
    int value12 = 0;

    // Start is called before the first frame update
    void Start()
    {
        L12T = gameObject.GetComponentsInChildren<Transform>();
        L12rows = new GameObject[L12T.Length];

        foreach (Transform trans in L12T)
        {
            value12++;
            L12rows.SetValue(trans.gameObject, value12 - 1);
        }
        value12 = 0;
        foreach (Transform trans in L12T)
        {
            if (L12rows[value12].tag != "Ignore" && L12rows[value12].tag != "Dam") 
            {
                L12rows[value12].SetActive(false);
            }
            value12++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (L12rows[logCount].tag == "Ignore")
        {
            logCount++;
        }
    }
}
// I'm tired.