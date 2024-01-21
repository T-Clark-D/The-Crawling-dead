using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    OverlayController overlayController;
    PlayerUIView playerUIView;
    public InputManager inputManager;

    public float health = 100;
    float maxHealth = 100;
    bool immune = false;
    public bool dead = false;
    // Start is called before the first frame update
    private void Awake()
    {
        overlayController = GameObject.Find("OverlayController").GetComponent<OverlayController>();
        playerUIView = overlayController.GetUIView();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead) return;
        if(collision.gameObject.tag == "Zombie" && !immune)
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            TakeDamage(zombie.strength);
            if (dead) return;
            StartCoroutine(ImmunityFrames());
        }

    }

    IEnumerator ImmunityFrames()
    {
        immune = true;
        yield return new WaitForSeconds(1);
        immune = false;
    }
    
    public void TakeKnockBack()
    {

    }

    private void TakeDamage(float strenght)
    {
        health -= strenght;
        if (health <= 0)
        {
            Death();
        }
        playerUIView.UpdateHealthBar(health,maxHealth);
    }

    private void Death()
    {
        playerUIView.ApplyDeathOverlay();
        inputManager.enabled = false;
        dead = true;
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        //Destroy(gameObject);
    }

    public void AddToScore(int score)
    {
        playerUIView.AddToHighScore(score);
    }
}
