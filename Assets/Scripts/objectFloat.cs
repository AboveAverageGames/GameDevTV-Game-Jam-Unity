using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectFloat : MonoBehaviour
{
    float speed = 0.01f;
    bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);
        }
        if (move == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed, transform.localPosition.z);
        }
        if (transform.localPosition.y <= -5)
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dam")
        {
            move = false;
        }
    }
}
