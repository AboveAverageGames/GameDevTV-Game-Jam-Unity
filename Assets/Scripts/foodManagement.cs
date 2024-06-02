using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodManagement : MonoBehaviour
{
    public float hungerVal = 1f;
    float decay = 0.00004f;
    public Slider hungerBar;
    public GameObject boy;
    public GameObject girl;
    public GameObject wife;
    int failC = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerVal = hungerVal - decay;
        if (hungerVal > 1)
        {
            hungerVal = 1;
        }
        hungerBar.value = hungerVal;
        if (hungerVal <= 0 && failC == 0)
        {
            print("boy ded");
            hungerVal = 1;
            failC++;
            decay = 0.00003f;
        }
        if (hungerVal <= 0 && failC == 1)
        {
            print("girl ded");
            hungerVal = 1;
            decay = 0.00002f;
            failC++;
        }
        if (hungerVal <= 0 && failC == 2)
        {
            print("wife ded");
            hungerVal = 1;
            decay = 0.00001f;
            failC++;
        }
        if (hungerVal <= 0 && failC == 3)
        {
            print("GameOver");
        }
    }
}
