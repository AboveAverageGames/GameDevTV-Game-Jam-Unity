using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectFloat : MonoBehaviour
{ 
    float storedSpeed;
    float speed = 0.01f;
    public float foodGain = 1;
    bool move = true;
    public foodManagement food;
    public PlayerController pMove;
    public buildTheDam dam;

    // Start is called before the first frame update
    void Start()
    {
        storedSpeed = speed;
        speed = storedSpeed;
        Debug.Log("Speed of Game Object is " + speed);
        Debug.Log("Stored speed is" + storedSpeed);
        food = GameObject.Find("Player").GetComponent<foodManagement>();
        pMove = GameObject.Find("Player").GetComponent<PlayerController>();
        dam = GameObject.Find("--- THE DAM ---").GetComponent<buildTheDam>();
    }

    //Makes the item able to move
    private void OnEnable()
    {
        storedSpeed = speed;
        speed = storedSpeed;
        move = true;

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
            gameObject.SetActive(false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dam")
        {
            move = false;
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Log" & pMove.carry == false)
        {
            pMove.carry = true;
            speed = 0;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = collision.transform;
            transform.localRotation = Quaternion.Euler(90, 0, 180);
            transform.localPosition = new Vector3(0, 0, 2);
            gameObject.tag = "HeldLog";
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Pol")
        {
            pMove.isSlowed = true;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Food")
        {
            food.hungerVal = food.hungerVal + foodGain;
            gameObject.SetActive(false);
        }
      //  if (collision.gameObject.tag == "Dam" & gameObject.tag == "HeldLog") < Moved down but keeping here for now
      //  {
      //      //Resets the log to defualt state so it can be pooled again
      //      Debug.Log("yippe");
      //      gameObject.tag = "Log";
      //      transform.SetParent(null);
      //      gameObject.SetActive(false);
      //      speed = storedSpeed;
      //  }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dam" & gameObject.tag == "HeldLog")
        {
            pMove.carry = false;
            dam.logCount++;
            gameObject.tag = "Log";
            GetComponent<BoxCollider>().isTrigger = false;
            transform.SetParent(null);
            gameObject.SetActive(false);
            speed = storedSpeed;
        }
    }
}
