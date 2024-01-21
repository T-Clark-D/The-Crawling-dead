using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManger : MonoBehaviour
{
    public LevelManager levelManager;
    public AudioSource audioSource;

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


    private static SFXManger instance;


    public void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        PlayerPrefsManager.SetSFXVolume(1f);
        //audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetSFXVolume();
        audioSource.time = 1f;
    }

    IEnumerator PlaySoundAndWait()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }

    public void PlayOptionsButtonClick()
    {
        audioSource.clip = buttonClick;
        StartCoroutine(PlaySoundAndWait());
        Debug.Log("options");
    }
    public void PlayStartGameClick()
    {
        audioSource.clip = startGameClick;
        StartCoroutine(PlaySoundAndWait());
        levelManager.LoadLevel("Game");
    }
    public void PlayHeadExplosion()
    {
        audioSource.clip = headExplosion;
        StartCoroutine(PlaySoundAndWait());
    }
    public void PlayNotificationClick()
    {
        audioSource.clip = notification;
        StartCoroutine(PlaySoundAndWait());
    }

    public void PlayZombieWalkSFX()
    {
        audioSource.clip = zombieWalkingList[zombieWalkingInd];
        zombieWalkingInd = (zombieWalkingInd + 1) % zombieWalkingList.Length;
        StartCoroutine(PlaySoundAndWait());
    }

    public void PlayZombieMoanSFX()
    {
        audioSource.clip = zombieMoaningList[zombieMoaningInd];
        zombieMoaningInd = (zombieMoaningInd + 1) % zombieMoaningList.Length;
        StartCoroutine(PlaySoundAndWait());
    }

    public void PlayZombieEatSFX()
    {
        audioSource.clip = zombieEatingList[zombieEatingInd];
        zombieEatingInd = (zombieEatingInd + 1) % zombieEatingList.Length;
        StartCoroutine(PlaySoundAndWait());
    }

    public void PlayShootSFX()
    {
        audioSource.clip = playerShootingList[playerShootingInd];
        playerShootingInd = (playerShootingInd + 1) % playerShootingList.Length;
        StartCoroutine(PlaySoundAndWait());
    }

    public void PlayPlayerRunSFX()
    {
        audioSource.clip = playerRunningList[playerRunningInd];
        playerRunningInd = (playerRunningInd + 1) % playerRunningList.Length;
        StartCoroutine(PlaySoundAndWait());
    }

}
