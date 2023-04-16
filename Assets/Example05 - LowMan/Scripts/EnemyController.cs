using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject player;
    public ThirdPersonCharacter character;

    void Start()
    {
        enemy.updateRotation = false;
    }

    void Update()
    {
        enemy.SetDestination(player.transform.position);

        if(enemy.remainingDistance > enemy.stoppingDistance)
        {
            character.Move(enemy.desiredVelocity, false, false);
        }
        else
        {
            character.Move(-Vector3.zero, false, false);
        }
    }
}
