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
            PlayerAnimationsNames anim = _playerInteractionSolver.DestinationReached();
            _playerAnimator.PlayAnim(anim);
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