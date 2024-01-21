using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXManger : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] zombieEatingList;
    private int zombieEatingInd = 0;
    public AudioClip[] zombieMoaningList;
    private int zombieMoaningInd = 0;
    public AudioClip[] zombieWalkingList;
    private int zombieWalkingInd = 0;

    public AudioClip[] playerRunningList;
    private int playerRunningInd = 0;
    public AudioClip[] playerShootingList;
    private int playerShootingInd = 0;

    public AudioClip buttonClick;
    public AudioClip startGameClick;
    public AudioClip notification;
    public AudioClip headExplosion;

    public void Start()
    {
        PlayerPrefsManager.SetSFXVolume(1f);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetSFXVolume();
        audioSource.time = 1f;
        PlayButtonClick();
        PlayStartGameClick();
        PlayZombieMoanSFX();
        PlayHeadExplosion();
    }

    public void PlayButtonClick()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }
    public void PlayStartGameClick()
    {
        audioSource.clip = startGameClick;
        audioSource.Play();
    }
    public void PlayHeadExplosion()
    {
        audioSource.clip = headExplosion;
        audioSource.Play();
    }
    public void PlayNotificationClick()
    {
        audioSource.clip = notification;
        audioSource.Play();
    }

    public void PlayZombieWalkSFX()
    {
        audioSource.clip = zombieWalkingList[zombieWalkingInd];
        zombieWalkingInd = (zombieWalkingInd + 1) % zombieWalkingList.Length;
        audioSource.Play();
    }

    public void PlayZombieMoanSFX()
    {
        audioSource.clip = zombieMoaningList[zombieMoaningInd];
        zombieMoaningInd = (zombieMoaningInd + 1) % zombieMoaningList.Length;
        audioSource.Play();
    }

    public void PlayZombieEatSFX()
    {
        audioSource.clip = zombieEatingList[zombieEatingInd];
        zombieEatingInd = (zombieEatingInd + 1) % zombieEatingList.Length;
        audioSource.Play();
    }

    public void PlayShootSFX()
    {
        audioSource.clip = playerShootingList[playerShootingInd];
        playerShootingInd = (playerShootingInd + 1) % playerShootingList.Length;
        audioSource.Play();
    }

    public void PlayPlayerRunSFX()
    {
        audioSource.clip = playerRunningList[playerRunningInd];
        playerRunningInd = (playerRunningInd + 1) % playerRunningList.Length;
        audioSource.Play();
    }

}
