using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    // Start is called before the first frame update
    public void Fire(Vector3 source, float angle, Vector2 direction, GameObject Projectile)
    {
        var projectile  = Instantiate(Projectile, source, Quaternion.Euler(0, 0, angle));
        projectile.GetComponent<Rigidbody2D>().AddForce(direction*300);
    }
}
