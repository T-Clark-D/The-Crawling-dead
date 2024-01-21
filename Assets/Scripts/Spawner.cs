using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> players;
    public Transform[] SpawnPoints;
    public Transform SpawnPointParent;
    // Start is called before the first frame update

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
            players.Add(objectWithTag);
        }
    }
    // Update is called once per frame
    public void Spawn(GameObject spawnableObject, int size)
    {
        int rand = Random.Range(0, SpawnPoints.Length);
        for(int i = 0; i<=size; i++)
            Instantiate(spawnableObject, SpawnPoints[rand]).GetComponent<Zombie>().Initilize(players);
    }

    /*public void SpawnWave(int sections, int waveLength, GameObject spawnableObject)
    {

    }*/
}
