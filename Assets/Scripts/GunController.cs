using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public Transform gun;
    public InputManager inputManager;
    public ProjectileManager bulletManager;

    public GameObject Bullet;

    public float Angle;

    ProjectileManager projectileManger;
    private Vector2 lastAimDirection = Vector2.right;

    private void Start()
    {
        projectileManger = GameObject.Find("ProjectileManager").GetComponent<ProjectileManager>();
    }

    internal void Fire()
    {
        projectileManger.Fire(transform.position, Angle, lastAimDirection.normalized, Bullet);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 aim = inputManager.AimDirection;

        if (aim == Vector2.zero)
            return;

        lastAimDirection = aim;

        aim = aim.normalized;
        var angle = Vector2.Angle(Vector2.right, aim);
        if (aim.y < 0)
        {
            angle = -angle;
        }
        if(aim.x < 0)
        {
            //gun.localScale = new Vector3(gun.localScale.x, -gun.localScale.y, 1);
            gun.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
        }

        gun.rotation = Quaternion.Euler(0, 0, angle);
        Angle = angle;

    }
}
