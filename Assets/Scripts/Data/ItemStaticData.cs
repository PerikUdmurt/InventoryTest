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
    
    [CreateAssetMenu(fileName = "NewAmmo", menuName = "StaticDatas/Ammo")]
    public class AmmoStaticData: ItemStaticData
    {
        public WeaponType WeaponType;
    }
    
    [CreateAssetMenu(fileName = "NewHealthPoint", menuName = "StaticDatas/HealthPotion")]
    public class HealthPotion: ItemStaticData
    {
        public int HP;
    }
    
    [CreateAssetMenu(fileName = "NewEquipment", menuName = "StaticDatas/Equipment")]
    public class EquipmentStaticData : ItemStaticData
    {
        public EquipmentType EquipmentType;
        public int Defense;
    }

    public enum WeaponType
    {
        Pistol = 0,
        Rifle = 1
    }

    public enum EquipmentType
    {
        Head = 0,
        Body = 1
    }
}
