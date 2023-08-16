using System;
using System.Collections;
using Interactables;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private IPlayerInteractionSolver _playerInteractionSolver;

    void Update()
    {
        // rotate player to moving side
        if (_agent.desiredVelocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_agent.desiredVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.tag.Equals(Constants.MovableArea))
                {
                    _playerInteractionSolver = null;
                    _agent.destination = hit.point;
                }
                else if (hit.transform.tag.Equals(Constants.InteractableArea))
                {
                    _playerInteractionSolver = hit.transform.GetComponent<IPlayerInteractionSolver>();
                    _playerInteractionSolver.Interact();
                }
            }
        }

        // if  =null -> "_agent.destination = hit.point;" already set
        if (_playerInteractionSolver != null)
            _agent.destination = _playerInteractionSolver.GetDestinationPosition();

        // if player reached destination point
        if (_playerInteractionSolver != null
            && Vector3.Distance(_agent.transform.position, _playerInteractionSolver.GetDestinationPosition()) <= Constants.PlayerReachDistance)
        {
            (PlayerAnimationsNames anim, bool isAnimLooped) = _playerInteractionSolver.DestinationReached();
            if (isAnimLooped)
                _playerAnimator.PlayAnim(anim);
            else
                _playerAnimator.PlayAnimOnce(anim, () => _playerInteractionSolver = null);
        }
        else
        {
            if (Vector3.Distance(_agent.transform.position, _agent.destination) <= Constants.PlayerWalkDistance)
                _playerAnimator.PlayAnim(PlayerAnimationsNames.Idle);
            else
                _playerAnimator.PlayAnim(PlayerAnimationsNames.Walk);
        }
    }
}