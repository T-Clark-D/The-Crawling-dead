using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 5;
    float speed;
    public Player player;

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
        if(zombie.TakeDamage(damage))
            player.AddToScore(10);
        else
            player.AddToScore(3);

        Destroy(gameObject);
    }


}
