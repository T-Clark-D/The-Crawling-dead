using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public Zombie zombie;
    public Transform CurrentTarget;
    Transform closestTarget;

    public void Start()
    {
        InvokeRepeating("UpdateTarget",1, 1f);
        if(zombie.Players.Count > 0) 
        {
            closestTarget = zombie.Players[0].transform;
        }
        else
        {
            Debug.Log("Lose.");
        }
    }
    void FixedUpdate()
    {
        if(CurrentTarget == null) return;
        var targetDirection = (CurrentTarget.position - transform.position);
        targetDirection = new Vector3(targetDirection.x, targetDirection.y, 0).normalized;
        transform.Translate(targetDirection * Time.deltaTime * zombie.speed, Space.World);
    }

    public void UpdateTarget()
    {
        if (zombie.Players.Count == 0)
        {
            return;
        }

        foreach (GameObject player in zombie.Players)
        {
            if(player.gameObject.GetComponent<Player>().dead)
            {
                zombie.Players.Remove(player);
                return;
            }
            if ((transform.position - player.transform.position).magnitude < (transform.position - closestTarget.position).magnitude)
            {
                closestTarget = player.transform;
            }
        }
        CurrentTarget = closestTarget;
    }
}
