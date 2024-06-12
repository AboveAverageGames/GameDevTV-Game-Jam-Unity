using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectFloat : MonoBehaviour
{ 
    float storedSpeed;
    private float speed = 10.3f;
    public float foodGain = 1;
    bool move = true;
    public foodManagement food;
    public PlayerController pMove;
    public buildTheDam dam;

    public GameManager gameManager;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        storedSpeed = speed;
        speed = storedSpeed;


        //Assigns Game Manager script
        gameManager = GameObject.Find("--- Game Manager ---").GetComponent<GameManager>();

        //Audio Manager
        audioManager = GameObject.Find("--- Audio Manager ---").GetComponent<AudioManager>();

        //Assigning Components
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
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed * Time.deltaTime);
        }
        if (move == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speed, transform.localPosition.z * Time.deltaTime);
        }
        if (transform.localPosition.y <= -5)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.tag == "HeldLog")
        {
            transform.localRotation = Quaternion.Euler(90, 0, 180);
            transform.localPosition = new Vector3(0, 0, 2);
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
            audioManager.PlaySFX(audioManager.pollution);
        }
        if (collision.gameObject.tag == "Player" & this.gameObject.tag == "Food")
        {

            audioManager.PlaySFX(audioManager.eating);

            food.hungerVal = food.hungerVal + foodGain;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dam" & gameObject.tag == "HeldLog")
        {
            audioManager.PlaySFX(audioManager.dambuild);

            pMove.carry = false;
            //HERE WE BUILD DAM DOUBLE TIME
            dam.damRow[dam.logCount].SetActive(true);
            dam.logCount++;
            dam.damRow[dam.logCount].SetActive(true);
            dam.logCount++;




            gameObject.tag = "Log";
            GetComponent<BoxCollider>().isTrigger = false;
            transform.SetParent(null);
            gameObject.SetActive(false);
            speed = storedSpeed;

            //Game manager stuff
            gameManager.logsPlacedThisLayer++;
            gameManager.logsPlacedThisLayer++;
        }
    }
}
