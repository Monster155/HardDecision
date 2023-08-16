using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPointsMove : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private float waitAtPointTime = 5f;
    // child component
    [SerializeField] private Transform visionTransform;

    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;
    private bool _isMoving = true;
    private Vector3 _lastRotation = Vector3.zero;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(MoveNPC());
    }

    private void Update()
    {
        // rotate NPC's vision to movement direction
        visionTransform.rotation = Quaternion.Euler(GetVisionRotation());
    }

    private IEnumerator MoveNPC()
    {
        while (_isMoving)
        {
            // move NPC to _currentWayPoint
            while (Vector3.Distance(transform.position, wayPoints[_currentWayPointIndex].position) >= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.SetDestination(wayPoints[_currentWayPointIndex].position);
                yield return null;
            }

            // stop NPC to wait for waitAtPointTime seconds at reached point
            yield return new WaitForSeconds(waitAtPointTime);

            // change waypoint to next
            _currentWayPointIndex++;
            if (_currentWayPointIndex >= wayPoints.Count)
                _currentWayPointIndex = 0;
        }
    }

    private Vector3 GetVisionRotation()
    {
        Vector3 rotation = _lastRotation;
        if (Mathf.Abs(_navMeshAgent.desiredVelocity.x) > 1 && Mathf.Abs(_navMeshAgent.desiredVelocity.z) < 1)
        {
            rotation = new Vector3(0, _navMeshAgent.desiredVelocity.x > 0 ? 90 : -90, 0);
        } else if (Mathf.Abs(_navMeshAgent.desiredVelocity.z) > 1 && Mathf.Abs(_navMeshAgent.desiredVelocity.x) < 1)
        {
            rotation = new Vector3(0, _navMeshAgent.desiredVelocity.z > 0 ? 0 : 180, 0);
        } else if (Mathf.Abs(_navMeshAgent.desiredVelocity.x) >= 1 && Mathf.Abs(_navMeshAgent.desiredVelocity.z) >= 1)
        {
            if (_navMeshAgent.desiredVelocity.x > 0 && _navMeshAgent.desiredVelocity.z > 0)
            {
                rotation = new Vector3(0, 45, 0);
            }
            if (_navMeshAgent.desiredVelocity.x > 0 && _navMeshAgent.desiredVelocity.z < 0)
            {
                rotation = new Vector3(0, 135, 0);
            }
            if (_navMeshAgent.desiredVelocity.x < 0 && _navMeshAgent.desiredVelocity.z > 0)
            {
                rotation = new Vector3(0, -45, 0);
            }
            if (_navMeshAgent.desiredVelocity.x < 0 && _navMeshAgent.desiredVelocity.z < 0)
            {
                rotation = new Vector3(0, -135, 0);
            }
        }

        _lastRotation = rotation;
        return rotation;
    }
}
