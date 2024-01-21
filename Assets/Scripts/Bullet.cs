using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] playerShootingList;
    private int playerShootingInd = 0;

    float speed;
    public Player player;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.volume = PlayerPrefsManager.GetSFXVolume();
        audioSource.time = 0.2f;
        audioSource.clip = playerShootingList[playerShootingInd];
        playerShootingInd = (playerShootingInd + 1) % playerShootingList.Length;
        audioSource.Play();
    }
    public void Sign(Player playersign)
    {
        player = playersign;
    }

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //12 is projectile bounds
        if (collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
            return;
        }
        Zombie zombie = collision.gameObject.GetComponent<Zombie>();
        //if he dies
        if(zombie.TakeDamage(player.damage))
            player.AddToScore(10);
        else
            player.AddToScore(3);

        Destroy(gameObject);
    }


}
