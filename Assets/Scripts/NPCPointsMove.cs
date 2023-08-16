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
    [SerializeField] private NpcAnimator _npcAnimator;

    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;
    private bool _isMoving;
    private Coroutine _moveCoroutine;
    private Vector3 _lastRotation = Vector3.zero;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _isMoving = false;
        ChangeMovementState(true);
    }

    private void Update()
    {
        // rotate NPC's vision to movement direction
        visionTransform.rotation = Quaternion.Euler(GetVisionRotation());
    }

    public void ChangeMovementState(bool isMoving)
    {
        if(isMoving == _isMoving)
            return;

        _isMoving = isMoving;
        
        if(_isMoving)
            _moveCoroutine = StartCoroutine(MoveNPC());
        else
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator MoveNPC()
    {
        while (_isMoving)
        {
            _npcAnimator.PlayAnim(NpcAnimationsNames.Walk);
            // move NPC to _currentWayPoint
            while (Vector3.Distance(transform.position, wayPoints[_currentWayPointIndex].position) >= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.SetDestination(wayPoints[_currentWayPointIndex].position);
                yield return null;
            }

            _npcAnimator.PlayAnim(NpcAnimationsNames.Idle);
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
