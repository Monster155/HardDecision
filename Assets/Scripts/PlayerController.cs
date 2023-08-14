using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private IPlayerInteractionSolver _playerInteractionSolver;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.tag.Equals(Constants.MovableArea))
                {
                    _agent.destination = hit.point;
                    _playerInteractionSolver = null;
                }
                else if (hit.transform.tag.Equals(Constants.InteractableArea))
                {
                    _playerInteractionSolver = hit.transform.GetComponent<IPlayerInteractionSolver>();
                    _playerInteractionSolver.Interact();

                    _agent.destination = _playerInteractionSolver.GetDestinationPosition();
                }
            }
        }

        // if player reached destination point
        if (_playerInteractionSolver != null
            && Vector3.Distance(_agent.transform.position, _playerInteractionSolver.GetDestinationPosition()) <= Constants.PlayerReachDistance)
        {
            _playerInteractionSolver.DestinationReached();
        }
    }
}