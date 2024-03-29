using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
    public Spawner spawner;
    public GameObject ZombiePrefab;
    //public static GameManager instance;
    public bool playersAreReady = false;

    public int WaveSize = 1;
    public int MinZombieHealth = 10;
    public int MaxZombieHealth = 15;

    /* private void Awake()
{
// Ensure there is only one instance of the singleton
if (instance != null && instance != this)
{
Destroy(this.gameObject);
}
else
{
instance = this;
DontDestroyOnLoad(this.gameObject);
}
playersAreReady = false;
}*/

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsManager.SetSFXVolume(0.2f);
        StartCoroutine(WaitingForPlayerReady());
    }

    IEnumerator WaitingForPlayerReady()
    {
        Debug.Log("we are waiting");
        yield return new WaitUntil(() => playersAreReady);
        Debug.Log("we are done waiting");
        spawner.Initialize();
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(IncreaseWaveSize());
        InvokeRepeating("SpawnZombie", 0, 2f);
        InvokeRepeating("PowerUpDelay", 3, 3f);
    }
    public void PowerUpDelay()
    {
        spawner.SpawnPowerUp();
    }
    IEnumerator IncreaseWaveSize()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            WaveSize += 1;
            MaxZombieHealth += 2;
        }
    }

    public void SpawnZombie()
    {
        Debug.Log("Spawning Zombies");
        spawner.Spawn(ZombiePrefab, WaveSize, UnityEngine.Random.Range(MinZombieHealth,MaxZombieHealth));
    }


}
