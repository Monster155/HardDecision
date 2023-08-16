using System;
using UnityEngine;

namespace Interactables
{
    public class NpcInteractionSolver : MonoBehaviour,IPlayerInteractionSolver
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private NpcAnimator _npcAnimator;
        [SerializeField] private NPCPointsMove _npcPointsMove;

        public void Interact()
        {
            // activate item shader
            _renderer.material.SetColor("_Color", Color.green);
        }
        public Vector3 GetDestinationPosition()
        {
            return transform.position;
        }
        public (PlayerAnimationsNames, bool) DestinationReached()
        {
            // activate another item shader
            _renderer.material.SetColor("_Color", Color.red);

            _npcPointsMove.ChangeMovementState(false);
            _npcAnimator.PlayAnim(NpcAnimationsNames.Deaf);

            return (PlayerAnimationsNames.KnifeAttack, false);
        }

        private void OnMouseEnter()
        {
            _renderer.material.SetColor("_Color", Color.yellow);
        }

        private void OnMouseExit()
        {
            _renderer.material.SetColor("_Color", Color.clear);
        }
    }
}