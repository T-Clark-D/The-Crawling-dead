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
    public float damage = 5;
    public bool dead = false;
    public float attackspeed = 0.2f;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererGun;
    public int grenadeCount = 0;

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
        switch (collision.gameObject.tag)
        {
            case "atkspdup":
                attackspeed = attackspeed/2;
                Destroy(collision.gameObject);
                break;
            case "mdkt":
                health = 100;
                playerUIView.UpdateHealthBar(health, maxHealth);
                Destroy(collision.gameObject);
                break;
            case "dmgup":
                damage = damage + 10;
                Destroy(collision.gameObject);
                break;
            case "grenade":
                grenadeCount++;
                Destroy(collision.gameObject);
                break;
        }
    }

    IEnumerator ImmunityFrames()
    {
        immune = true;
        Color flash = Color.black;
        flash.a = 0.5f;
        spriteRenderer.color = flash;
        spriteRendererGun.color = flash;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        spriteRendererGun.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = flash;
        spriteRendererGun.color = flash;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        spriteRendererGun.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = flash;
        spriteRendererGun.color = flash;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        spriteRendererGun.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = flash;
        spriteRendererGun.color = flash;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        spriteRendererGun.color = Color.white;
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
