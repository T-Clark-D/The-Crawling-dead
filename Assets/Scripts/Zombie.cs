using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    float health = 10;
    public float strength = 10;
    public List<GameObject> Players;
    public Pathing pathing;
    // Start is called before the first frame update

    public void Initilize(List<GameObject> players)
    {
        Players = players;
        pathing.enabled = true;

    }
    public bool TakeDamage(float damage)
    {
        health = health - damage;
        if (health < 0) 
        {
            Death();
            return true;
        }
        return false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
