using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    float health;
    public float strength = 10;
    public List<GameObject> Players;
    public Pathing pathing;
    public SpriteRenderer spriteRenderer;


    private AudioSource audioSource;
    public AudioClip[] zombieMoaningList;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Initilize(List<GameObject> players, int zombieInd, float hp)
    {
        float sizemod = 0.25f + ((hp - 10) / 30);
        transform.localScale = new Vector3(sizemod, sizemod, 0);
        health = hp;

        audioSource = GetComponent<AudioSource>();
        Players = players;
        pathing.enabled = true;
        audioSource.clip = zombieMoaningList[zombieInd];
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        transform.position= new Vector3(transform.position.x, transform.position.y, (transform.position.y+10));
    }
    public bool TakeDamage(float damage)
    {
        health -= damage;
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
