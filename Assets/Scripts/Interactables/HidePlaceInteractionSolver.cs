using System;
using UnityEngine;

namespace Interactables
{
    public class HidePlaceInteractionSolver : MonoBehaviour, IPlayerInteractionSolver
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private GameObject _anim;

        private void Start()
        {
            _renderer.material.SetColor("_Color", Color.clear);
            _anim.SetActive(false);
        }

        public void Interact()
        {
            // activate item shader
            _renderer.material.SetColor("_Color", Color.blue);
        }
        public Vector3 GetDestinationPosition()
        {
            return transform.position;
        }
        public (PlayerAnimationsNames, bool) DestinationReached()
        {
            // activate another item shader
            _renderer.material.SetColor("_Color", Color.clear);
            return (PlayerAnimationsNames.Hide, true);
        }

        private void OnMouseEnter()
        {
            _renderer.material.SetColor("_Color", Color.white);
            _anim.SetActive(true);
        }

        private void OnMouseExit()
        {
            _renderer.material.SetColor("_Color", Color.clear);
            _anim.SetActive(false);
        }
    }
}