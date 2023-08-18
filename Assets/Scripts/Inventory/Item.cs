using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "ScriptableObject/Item")]
    public class Item : ScriptableObject
    {
        public Sprite image;
        public bool stackable = true;
        public ItemType type;
        public ActionType actionType;

        public enum ItemType
        {
            Weapon,
            Food,
            Collectable
        }

        public enum ActionType
        {
            // ?
        }
    }
}
