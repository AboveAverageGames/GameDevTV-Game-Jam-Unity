using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodManagement : MonoBehaviour
{
    public float hungerVal = 1f;
    public float decay = 0.01f;
    public Slider hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerVal = hungerVal - decay;
        hungerBar.value = hungerVal;
    }
}
