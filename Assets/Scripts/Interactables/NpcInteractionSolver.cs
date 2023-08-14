using UnityEngine;

namespace Interactables
{
    public class NpcInteractionSolver : MonoBehaviour,IPlayerInteractionSolver
    {
        public void Interact()
        {
            // activate item shader
        }
        public Vector3 GetDestinationPosition()
        {
            return transform.position;
        }
        public void DestinationReached()
        {
            // activate another item shader
        }
    }
}