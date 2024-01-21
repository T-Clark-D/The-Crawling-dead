using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> playerGOs;
    public List<Player> players;
    public Transform[] SpawnPoints;
    public Transform SpawnPointParent;
    public bool disableSpawn = false;
    // Start is called before the first frame update
    public GameObject GrenadePrefab;
    public GameObject MedKitPrefab;
    public GameObject AtkSpdPrefab;
    public GameObject DmgPrefab;

    public Transform powerUpPointer;

    private void CheckIfPlayersAreDead()
    {
        foreach (Player player in players)
        {
            if (!player.dead)
            {
                return;
            }
        }
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
    // Update is called once per frame
    public void Spawn(GameObject spawnableObject, int size)
    {
        if (disableSpawn) return;
        for (int i = 0; i <= size; i++)
        {
            int rand = Random.Range(0, SpawnPoints.Length);
            Instantiate(spawnableObject, SpawnPoints[rand]).GetComponent<Zombie>().Initilize(playerGOs);
        }

    }
    public void SpawnPowerUp()
    {
        GameObject chosenPowerup;
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                chosenPowerup = GrenadePrefab;
                break;
            case 1:
                chosenPowerup = MedKitPrefab; break;
            case 2:
                chosenPowerup = AtkSpdPrefab; break;
            case 3:
                chosenPowerup = DmgPrefab; break;
                default: chosenPowerup = AtkSpdPrefab; break;

        }
        var x = Random.Range(-8, 8);
        var y = Random.Range(-4, 4);

        Instantiate(chosenPowerup, new Vector3(x, y, y + 10),Quaternion.identity);

    }

    /*public void SpawnWave(int sections, int waveLength, GameObject spawnableObject)
    {

    }*/
}
