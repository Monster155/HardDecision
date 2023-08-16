using System;
using UnityEngine;

namespace Interactables
{
    public class ItemInteractionSolver : MonoBehaviour, IPlayerInteractionSolver
    {
        [SerializeField] private SpriteRenderer _renderer;

        public void Interact()
        {
            // activate item shader
            _renderer.material.SetColor("_Color", Color.yellow);
        }
        public Vector3 GetDestinationPosition()
        {
            return transform.position;
        }
        public (PlayerAnimationsNames, bool) DestinationReached()
        {
            // activate another item shader
            _renderer.material.SetColor("_Color", Color.red);
            return (PlayerAnimationsNames.Pick, false);
        }
    }
}