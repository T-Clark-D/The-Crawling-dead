using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> players;

    public Transform SpawnZone;
    // Start is called before the first frame update


    public void Initialize()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject objectWithTag in objectsWithTag)
        {
            Debug.Log(objectWithTag.name);
            players.Add(objectWithTag);
        }
    }
    // Update is called once per frame
    public void Spawn(GameObject spawnableObject)
    {
        Instantiate(spawnableObject).GetComponent<Zombie>().Initilize(players);
    }

    /*public void SpawnWave(int sections, int waveLength, GameObject spawnableObject)
    {

    }*/
}
