using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNNight : MonoBehaviour
{
    public float daySpeed = 0.025f;
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(daySpeed+count, 0, 0);
        count = count + daySpeed;
    }
}
