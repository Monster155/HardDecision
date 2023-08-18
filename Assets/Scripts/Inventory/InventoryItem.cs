using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour//, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [HideInInspector]
        public Item item;

        public Image image;
        public TextMeshProUGUI countText;

        [HideInInspector]
        public Transform parentAfterDrag;

        [HideInInspector]
        public int itemsCount = 1;

        private Canvas _mainCanvas;

        private void Start ()
        {
            _mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        }

        public void InitializeItem(Item newItem)
        {
            item = newItem;
            image.sprite = newItem.image;
            RefreshCount();
        }

        public void RefreshCount()
        {
            countText.text = itemsCount.ToString();
        
            countText.gameObject.SetActive(itemsCount > 1);
        }

        // public void OnBeginDrag (PointerEventData eventData)
        // {
        //     image.raycastTarget = false;
        //     parentAfterDrag = transform.parent;
        //     transform.SetParent(transform.root);
        // }
        //
        // public void OnDrag (PointerEventData eventData)
        // {
        //     Vector2 pos;
        //     RectTransformUtility.ScreenPointToLocalPointInRectangle(_mainCanvas.transform as RectTransform, 
        //         Input.mousePosition, _mainCanvas.worldCamera, out pos);
        //     transform.position = _mainCanvas.transform.TransformPoint(pos);
        // }
        //
        // public void OnEndDrag (PointerEventData eventData)
        // {
        //     image.raycastTarget = true;
        //     transform.SetParent(parentAfterDrag);
        // }
    }
}
