using UnityEngine;

namespace Interactables
{
    public interface IPlayerInteractionSolver
    {
        public void Interact();
        public Vector3 GetDestinationPosition();
        public void DestinationReached();
    }
}