using InventoryTest.Data;
using InventoryTest.Gameplay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryTest.Services
{
    public class LootService
    {
        private const string staticDataPath = "StaticDatas";
        private readonly InventoryTest.Gameplay.Inventory _inventory;
        private List<ItemStaticData> itemStaticDatas = new List<ItemStaticData>();

        public LootService(Gameplay.Inventory inventory) 
        {
            itemStaticDatas = Resources.LoadAll<ItemStaticData>(staticDataPath).ToList();
            _inventory = inventory;
        }

        public void GiveRandomLoot()
        {
            IInventorySlot emptySlot = _inventory.GetEmptySlot();

            //emptySlot.TakeItem();
        }
    }
}