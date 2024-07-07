using UnityEngine;
namespace InventoryTest.Data
{
    [CreateAssetMenu(fileName = "NewHealthPoint", menuName = "StaticDatas/HealthPotion")]
    public class HealthPotion: ItemStaticData
    {
        public int HP;
    }
}
