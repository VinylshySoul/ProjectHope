using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class BBDGuards : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Vector3 target;
    private int direction = 1;
    private int targetIndex = 1;
    [HideInInspector] public Transform player;
    [HideInInspector] public bool canFire = true;
    public PatrolPoint[] points;
    public GameObject bullet;
    public float bulletForce;
    public float playerDetectDistance;
    public float distanceCheckFrequency;
    public MeshRenderer Eyes;
    public Material yellowGlow;
    public Material redGlow;

    private BBDGuardState currentState;
    public readonly BBDGuardPatrolState patrolState = new BBDGuardPatrolState();
    public readonly BBDGuardFireState fireState = new BBDGuardFireState();
    public readonly BBDGuardPursueState pursueState = new BBDGuardPursueState();
    public readonly BBDGuardDisableState disableState = new BBDGuardDisableState();
   

    // Start is called before the first frame update
    void Start()
    {
        Eyes.material.color =Color.yellow;
        agent = GetComponent<NavMeshAgent>();
        if (points.Length > 0)
        {
            target = points[targetIndex].transform.position;
        }

        player = GameObject.FindWithTag("Player").transform;
        TransitionToState(patrolState);
    }
    
    void Update()
    {
        currentState.UpdateState(this);
    }

    public Vector3 SetNextTarget()
    {
        targetIndex += direction;
        if (targetIndex == points.Length)
        {
            direction = -1;
            targetIndex = points.Length - 2;
        }
        else if (targetIndex < 0)
        {
            direction = 1;
            targetIndex = 1;
        }
        target = points[targetIndex].transform.position;
        return target;
    }

    public void FireBullet()
    {
        var direction = player.position - transform.position;
        var b = Instantiate(bullet, transform.position, Quaternion.identity);
        var r = b.GetComponent<Rigidbody>();
        r.AddForce(direction * bulletForce, ForceMode.Impulse);
    }

    public bool PlayerWithinRange()
    {
        var dist = Vector3.Distance(transform.position, player.position);
        return (dist < playerDetectDistance);
    }
    
    public void Disable()
    {
        TransitionToState(disableState);
    }

    public void TransitionToState(BBDGuardState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
