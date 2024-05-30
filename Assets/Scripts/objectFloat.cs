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

    //Makes the item able to move
    private void OnEnable()
    {
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
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Log")
        {
            speed = 0;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = collision.transform;
            transform.localRotation = Quaternion.Euler(90, 0, -90);
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
        if (collision.gameObject.tag == "Dam" & this.gameObject.tag == "HeldLog")
        {
            Debug.Log("yippe");
            Destroy(gameObject);
        }
    }
}
