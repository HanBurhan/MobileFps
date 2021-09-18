using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMesh;

    private Transform player;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Vector3 distanceFromPlayer = player.position - transform.position;

        navMesh.SetDestination(player.position);
        transform.rotation = Quaternion.LookRotation(distanceFromPlayer, Vector3.up);
    }
}
