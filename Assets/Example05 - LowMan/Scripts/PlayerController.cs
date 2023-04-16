using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public NavMeshAgent enemy;
    public ThirdPersonCharacter character;
    public float speedIncrement = 0.05f;
    Spawner spawn;


    void Start()
    {
        agent.updateRotation = false;

        spawn = FindObjectOfType<Spawner>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //MOVING AGENT
                agent.SetDestination(hit.point);
            }
        }

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(-Vector3.zero, false, false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Pickup")
        {
            Debug.Log("Score +1");
            Score.tempScore++;
            Destroy(col.gameObject);
            enemy.speed = enemy.speed + speedIncrement;
            spawn.Spawn();
        }
    }
}
