using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        
        public InventorySlot[] inventorySlots;
        public GameObject inventoryItemPrefab;

        public int maxStackCount = 5;

        private int _selectedSlot = -1;

        private int _maxInventoryIndexCount = 7;

        private void Start ()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
            
            ChangeSelectedSlot(0);
        }

        private void Update ()
        {
            if (Input.mouseScrollDelta.y < 0)
                ChangeSelectedSlot(_selectedSlot + 1);
            else if (Input.mouseScrollDelta.y > 0)
                ChangeSelectedSlot(_selectedSlot - 1);

            if (Input.inputString != null) {
                bool isNumberPressed = int.TryParse(Input.inputString, out int number);
                if (isNumberPressed && number > 0 && number < 9) {
                    ChangeSelectedSlot(number - 1);
                }
            }
        }

        private void ChangeSelectedSlot(int value)
        {
            if (_selectedSlot >= 0) {
                inventorySlots[_selectedSlot].Deselect();
            }

            if (value < 0) {
                value = _maxInventoryIndexCount;
            }
            else if (value > _maxInventoryIndexCount) {
                value = 0;
            }

            inventorySlots[value].Select();
            _selectedSlot = value;
        }

        public bool AddItem(Item item)
        {
            // search for empty slot in inventory and place item there
            for (int i = 0; i < inventorySlots.Length; i++) {
                InventorySlot inventorySlot = inventorySlots[i];
                InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && 
                    itemInSlot.item == item && 
                    itemInSlot.itemsCount < maxStackCount &&
                    itemInSlot.item.stackable == true) 
                {
                    itemInSlot.itemsCount++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }

            for (int i = 0; i < inventorySlots.Length; i++) {
                InventorySlot inventorySlot = inventorySlots[i];
                InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null) {
                    SpawnItem(item, inventorySlot);
                    return true;
                }
            }

            return false;
        }

        private void SpawnItem(Item item, InventorySlot inventorySlot)
        {
            GameObject newItemGameObject = Instantiate(inventoryItemPrefab, inventorySlot.transform);
            InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
            inventoryItem.InitializeItem(item);
        }

        public Item GetSelectedItemInfo()
        {
            InventorySlot inventorySlot = inventorySlots[_selectedSlot];
            InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) {
                return itemInSlot.item;
            } else {
                return null; 
            }
        }

        public Item GetSelectedItem(bool usingItem)
        {
            InventorySlot inventorySlot = inventorySlots[_selectedSlot];
            InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) {
                Item item = itemInSlot.item;
                if (usingItem) {
                    itemInSlot.itemsCount--;
                    if (itemInSlot.itemsCount <= 0) {
                        Destroy(itemInSlot.gameObject);
                    } else {
                        itemInSlot.RefreshCount();
                    }
                }
                return item;
            }

            return null;
        }
    }
}
