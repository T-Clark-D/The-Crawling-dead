using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public Zombie zombie;
    public Transform CurrentTarget;
    Transform closestTarget;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Start()
    {
        InvokeRepeating("UpdateTarget",1, 1f);
        closestTarget = zombie.Players[0].transform;
    }
    void FixedUpdate()
    {
        if(CurrentTarget == null) return;
        var targetDirection = (CurrentTarget.position - transform.position);
        targetDirection = new Vector3(targetDirection.x, targetDirection.y, 0).normalized;
        transform.Translate(targetDirection * Time.deltaTime * 2f, Space.World);
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
