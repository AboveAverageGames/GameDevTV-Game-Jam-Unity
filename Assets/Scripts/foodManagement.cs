using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodManagement : MonoBehaviour
{
    public float hungerVal = 1f;
    public float decay;
    private float decayStore;
    public Slider hungerBar;
    public GameObject boy;
    public GameObject girl;
    public GameObject wife;
    int failC = 0;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("--- Audio Manager ---").GetComponent<AudioManager>();

        decayStore = decay;
    }

    // Update is called once per frame
    void Update()
    {
        hungerVal = hungerVal - decay * Time.deltaTime;
        hungerBar.value = hungerVal;


        //Hunger Detection
        if (hungerVal > 1)
        {
            hungerVal = 1;
        }
        if (hungerVal <= 0 && failC == 0)
        {
            print("boy ded");
            audioManager.ChangeBGMusic(audioManager.backgroundMusic2FamilyAlive);
            audioManager.PlaySFX(audioManager.deathSound);
            hungerVal = 1;
            failC++;
            decay = decayStore;
        }
        if (hungerVal <= 0 && failC == 1)
        {
            print("girl ded");
            audioManager.ChangeBGMusic(audioManager.backgroundMusic1FamilyAlive);
            audioManager.PlaySFX(audioManager.deathSound);
            hungerVal = 1;
            decay = decayStore;
            failC++;
        }
        if (hungerVal <= 0 && failC == 2)
        {
            print("wife ded");
            audioManager.ChangeBGMusic(audioManager.backgroundMusic0FamilyAlive);
            audioManager.PlaySFX(audioManager.deathSound);  
            hungerVal = 1;
            decay = decayStore;
            failC++;
        }
        if (hungerVal <= 0 && failC == 3)
        {
            print("GameOver");
        }
    }
}
