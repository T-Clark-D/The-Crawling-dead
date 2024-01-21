using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> playerGOs;
    public List<Player> players;
    public Transform[] SpawnPoints;
    public Transform SpawnPointParent;
    public bool disableSpawn = false;

    public GameObject MedKitPrefab;
    public GameObject AtkSpdPrefab;
    public GameObject DmgPrefab;

    public Transform powerUpPointer;

    private int zombieMoaningInd = 0;
    public AudioClip[] zombieMoaningList;
    public GameObject Gameover;

    private void CheckIfPlayersAreDead()
    {
        foreach (Player player in players)
        {
            if (!player.dead)
            {
                return;
            }
        }
        Gameover.SetActive(true);
        disableSpawn = true;


    }
    private void Awake()
    {
        SpawnPoints = SpawnPointParent.GetComponentsInChildren<Transform>();
    }
    public void Initialize()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject objectWithTag in objectsWithTag)
        {
            Debug.Log(objectWithTag.name);
            playerGOs.Add(objectWithTag);
            players.Add(objectWithTag.GetComponent<Player>());
        }
        InvokeRepeating("CheckIfPlayersAreDead", 0, 1f);
    }

    public void Spawn(GameObject spawnableObject, int waveSize, float hp)
    {
        int zombieMoaningInd = 0;
        if (disableSpawn) return;
        for (int i = 0; i <= waveSize; i++)
        {
            zombieMoaningInd = (zombieMoaningInd + 1) % zombieMoaningList.Length;
            int rand = Random.Range(0, SpawnPoints.Length);
            Instantiate(spawnableObject, SpawnPoints[rand]).GetComponent<Zombie>().Initilize(playerGOs, zombieMoaningInd, hp);
        }

    }
    public void SpawnPowerUp()
    {
        GameObject chosenPowerup;
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                chosenPowerup = DmgPrefab; break;
            case 1:
                chosenPowerup = MedKitPrefab; break;
            case 2:
                chosenPowerup = AtkSpdPrefab; break;
                default: chosenPowerup = AtkSpdPrefab; break;

        }
        var x = Random.Range(-8, 8);
        var y = Random.Range(-4, 4);

        Instantiate(chosenPowerup, new Vector3(x, y, y + 10),Quaternion.identity);

    }

}
