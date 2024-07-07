using UnityEngine;
namespace InventoryTest.Data
{
    [CreateAssetMenu(fileName = "NewEquipment", menuName = "StaticDatas/Equipment")]
    public class EquipmentStaticData : ItemStaticData
    {
        public EquipmentType EquipmentType;
        public int Defense;
    }
}
