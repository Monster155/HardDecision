using UnityEngine;

namespace Interactables
{
    public interface IPlayerInteractionSolver
    {
        public void Interact();
        public Vector3 GetDestinationPosition();
        public (PlayerAnimationsNames, bool) DestinationReached();
    }
}