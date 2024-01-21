using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
    public Spawner spawner;
    public GameObject ZombiePrefab;

    public bool playersAreReady = false;
    // Start is called before the first frame update
    void Start()
    {
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
        InvokeRepeating("SpawnZombie", 0, 1f);
    }

    public void SpawnZombie()
    {
        Debug.Log("Spawning Zombies");
        spawner.Spawn(ZombiePrefab);
    }
}
