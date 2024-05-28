using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectFloat : MonoBehaviour
{
    float speed = 0.01f;
    public float foodGain = 1;
    bool move = true;
    public foodManagement food;
    public PlayerController pMove;

    // Start is called before the first frame update
    void Start()
    {
       food = GameObject.Find("Player").GetComponent<foodManagement>();
       pMove = GameObject.Find("Player").GetComponent<PlayerController>();
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
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Log")
        {
            Debug.Log("PlayerLog");
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Pol")
        {
            pMove.isSlowed = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Food")
        {
            food.hungerVal = food.hungerVal + foodGain;
            Destroy(gameObject);
        }
    }
}
