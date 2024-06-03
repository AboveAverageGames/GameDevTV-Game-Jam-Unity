using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSouce;
    [SerializeField] AudioSource AmbientMusic;

    [Header("----- Audio Clip -----")]
    public AudioClip backgroundMusic3FamilyAlive;
    public AudioClip backgroundMusic2FamilyAlive;
    public AudioClip backgroundMusic1FamilyAlive;
    public AudioClip backgroundMusic0FamilyAlive;

    public AudioClip LoseGame;
    public AudioClip WinGame;


    public AudioClip dambuild;
    public AudioClip eating;
    public AudioClip deathSound;
    public AudioClip pollution;


    public AudioClip waterRunning;


    //Plays the BG music on start up
    private void Start()
    {
        musicSource.clip = backgroundMusic3FamilyAlive;
        musicSource.Play();

        AmbientMusic.clip = waterRunning;
        AmbientMusic.Play();
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
