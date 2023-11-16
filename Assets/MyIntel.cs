using UnityEngine;
using UnityEngine.AI;

public class MyIntel : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    [SerializeField] private float changePositionTime = 5f;
    [SerializeField] private float moveDistance = 10f;
    [SerializeField] private float movementSpeed;
    private float TimeSave;
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = movementSpeed;
        // _animator = GetComponent<Animator>();
        InvokeRepeating(nameof(RandomNavSphere),changePositionTime,changePositionTime);
    }

    private void Update()
    {
        if (Time.time > TimeSave)
        {
            MoveZombie();
            TimeSave = Time.time + 5;
        }
    }

    Vector3 RandomNavSphere(float distance)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);
        return navHit.position;
    }

    private void MoveZombie()
    {
        _navMeshAgent.SetDestination(RandomNavSphere(moveDistance));
    }
}