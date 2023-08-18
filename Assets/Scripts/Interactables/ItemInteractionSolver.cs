using System;
using Inventory;
using UnityEngine;

namespace Interactables
{
    public class ItemInteractionSolver : MonoBehaviour, IPlayerInteractionSolver
    {
        [SerializeField] private Item item;
        [SerializeField] private SpriteRenderer _renderer;

        private InventoryManager _inventoryManager;

        public bool _itemGaved = false;

        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
        }

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
            if (_itemGaved == false)
            {
                _inventoryManager.AddItem(item);
                _itemGaved = true;
            }
            return (PlayerAnimationsNames.Pick, false);
        }
    }
}