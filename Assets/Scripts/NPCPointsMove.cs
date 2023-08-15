using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPointsMove : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private float waitAtPointTime = 5f;

    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;
    private bool _isMoving = true;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(MoveNPC());
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
}
