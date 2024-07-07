using UnityEngine;
namespace InventoryTest.Data
{
    public abstract class ItemStaticData : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public float Weight;
        public int MaxStack;
    }
}
