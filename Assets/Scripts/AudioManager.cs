using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSouce;

    [Header("----- Audio Clip -----")]
    public AudioClip backgroundMusic3FamilyAlive;
    public AudioClip backgroundMusic2FamilyAlive;
    public AudioClip backgroundMusic1FamilyAlive;


    public AudioClip woodCollection;
    public AudioClip playerDeathSound;
    public AudioClip collisionWithDam;
    public AudioClip nextLevelSound;


    public AudioClip UISound;


    //Plays the BG music on start up
    private void Start()
    {
        musicSource.clip = backgroundMusic3FamilyAlive;
        musicSource.Play();
    }

    //Public method that will play the SFX that is fed into it
    public void PlaySFX(AudioClip Clip)
    {
        SFXSouce.PlayOneShot(Clip);
    }

    public void ChangeBGMusic(AudioClip Clip)
    {
        musicSource.clip = (Clip);
        musicSource.Play();
    }
}
