using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 5;
    float speed;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //12 is projectile bounds
        if (collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
            Debug.Log("weeeeeeeeeeeee");
            return;
        }
        Zombie zombie = collision.gameObject.GetComponent<Zombie>();
        zombie.TakeDamage(damage);
    }


}
