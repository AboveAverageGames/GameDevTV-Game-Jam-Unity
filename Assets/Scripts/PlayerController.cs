using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 move;
    float storeSpeed;
    public float slow = 0.5f;
    public bool isSlowed = false;
    public bool carry = false;


    public GameManager gameManager;

    void Start()
    {

        //Stores the speed
        storeSpeed = speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //This function is Invoked through the Input manager
        //Takes the Input from the new Input System (Left stick and W,A,S,D)
        move = context.ReadValue<Vector2>();
    }



    //Move Player
    public void MovePlayer()
    {
        //Creates a Vector for the movement read from the Input of the player
        Vector3 movement = new Vector3(- move.x, 0, -move.y);

        //Applies the movement to the player keeping track of the world space and time
        transform.Translate( movement * speed * Time.deltaTime, Space.World);

        //Rotating player towards direction, In a if statement so the rotation doesnt RESET when there is no movement
        if (movement != Vector3.zero)
        {
            //Rotates the player towards the direction, the number at the end controls the SPEED of the rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), 1000f * Time.deltaTime);
        }
        }



    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (isSlowed==true)
        {
            StartCoroutine(Slowed());
            isSlowed = false;
        }
    }
    
    IEnumerator Slowed()
    {
        speed = speed * slow;
        yield return new WaitForSeconds(5);
        speed = storeSpeed;
    }
}
