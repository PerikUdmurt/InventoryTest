using UnityEngine;
namespace InventoryTest.Data
{
    [CreateAssetMenu(fileName = "NewAmmo", menuName = "StaticDatas/Ammo")]
    public class AmmoStaticData: ItemStaticData
    {
        public WeaponType WeaponType;
    }
}
