using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    float health = 10;
    public float strength = 10;
    public List<GameObject> Players;
    public Pathing pathing;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public void Initilize(List<GameObject> players)
    {
        Players = players;
        pathing.enabled = true;

    }

    private void FixedUpdate()
    {
        transform.position= new Vector3(transform.position.x, transform.position.y, (transform.position.y+10));
    }
    public bool TakeDamage(float damage)
    {
        health = health - damage;
        if (health < 0) 
        {
            Death();
            return true;
        }
        StartCoroutine(DamageIndicator());
        return false;
    }

    IEnumerator DamageIndicator()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
