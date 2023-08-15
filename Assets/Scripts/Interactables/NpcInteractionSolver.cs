using System;
using UnityEngine;

namespace Interactables
{
    public class NpcInteractionSolver : MonoBehaviour,IPlayerInteractionSolver
    {
        [SerializeField] private SpriteRenderer _renderer;

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

        private void OnMouseEnter()
        {
            _renderer.material.SetColor("_Color", Color.yellow);
        }

        private void OnMouseExit()
        {
            _renderer.material.SetColor("_Color", Color.blue);
        }
    }
}