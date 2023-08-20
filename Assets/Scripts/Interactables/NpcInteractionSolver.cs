using System;
using Inventory;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables
{
    public class NpcInteractionSolver : MonoBehaviour,IPlayerInteractionSolver
    {
        public UnityEvent OnNpcDied;
        
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private NpcAnimator _npcAnimator;
        [SerializeField] private NPCPointsMove _npcPointsMove;

        [SerializeField] private Item[] itemsInPockets;
        [SerializeField] private int moneyInPockets;

        private bool _isDead = false;
        private bool _moneyGaved = false;
        private bool _itemsGaved = false;

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
            if (_isDead == false)
            {
                _npcAnimator.PlayAnim(NpcAnimationsNames.Deaf);
                _isDead = true;
                OnNpcDied?.Invoke();
                return (PlayerAnimationsNames.KnifeAttack, false);
            }
            else
            {
                // search for items & money
                if (moneyInPockets > 0 && _moneyGaved == false)
                {
                    MoneyManager.Instance.AddMoney(moneyInPockets);
                    _moneyGaved = true;
                }
                if (itemsInPockets.Length > 0 && _itemsGaved == false)
                {
                    for (int i = 0; i < itemsInPockets.Length; i++)
                    {
                        InventoryManager.Instance.AddItem(itemsInPockets[i]);
                    }

                    _itemsGaved = true;
                }
                return (PlayerAnimationsNames.Pick, false);
            }
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