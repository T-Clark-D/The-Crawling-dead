using System.Collections;
using System.Collections.Generic;
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
    //public AudioClip[] playerExplosionList;
    //private int playerExplosionInd = 0;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playZombieWalkSFX()
    {
        audioSource.clip = zombieWalkingList[zombieWalkingInd];
        zombieWalkingInd = (zombieWalkingInd + 1) % zombieWalkingList.Length;
        audioSource.Play();
    }

    public void playZombieMoanSFX()
    {
        audioSource.clip = zombieMoaningList[zombieMoaningInd];
        zombieMoaningInd = (zombieMoaningInd + 1) % zombieMoaningList.Length;
        audioSource.Play();
    }

    public void playZombieEatSFX()
    {
        audioSource.clip = zombieEatingList[zombieEatingInd];
        zombieEatingInd = (zombieEatingInd + 1) % zombieEatingList.Length;
        audioSource.Play();
    }

    public void playShootSFX()
    {
        audioSource.clip = playerShootingList[playerShootingInd];
        playerShootingInd = (playerShootingInd + 1) % playerShootingList.Length;
        audioSource.Play();
    }

    public void playPlayerRunSFX()
    {
        audioSource.clip = playerRunningList[playerRunningInd];
        playerRunningInd = (playerRunningInd + 1) % playerRunningList.Length;
        audioSource.Play();
    }

}
