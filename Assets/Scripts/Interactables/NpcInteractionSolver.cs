﻿using System;
using UnityEngine;

namespace Interactables
{
    public class NpcInteractionSolver : MonoBehaviour,IPlayerInteractionSolver
    {
        [SerializeField] private SpriteRenderer _renderer;

        public void Interact()
        {
            // activate item shader
            _renderer.material.SetColor("_Color", Color.green);
        }
        public Vector3 GetDestinationPosition()
        {
            return transform.position;
        }
        public PlayerAnimationsNames DestinationReached()
        {
            // activate another item shader
            _renderer.material.SetColor("_Color", Color.red);
            return PlayerAnimationsNames.KnifeAttack;
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