using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image slotImage;
        //public Sprite standartImage;
        //public Sprite selectedImage;
        [SerializeField] private Color standartColor;
        [SerializeField] private Color selectedColor;

        private void Awake ()
        {
            Deselect();
        }

        public void Select()
        {
            //slotImage.sprite = selectedImage;
            slotImage.color = selectedColor;
        }

        public void Deselect()
        {
            //slotImage.sprite = standartImage;
            slotImage.color = standartColor;
        }
    }
}
