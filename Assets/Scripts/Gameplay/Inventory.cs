using Inventory.UI;
using InventoryTest.Infrastructure.Factory;
using InventoryTest.Services.SaveLoad;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public class Inventory : IDataSaver
    {
        private Dictionary<IInventorySlot, IItem> _inventory = new Dictionary<IInventorySlot, IItem>();
        private readonly SlotFactory _slotFactory;
        private readonly PopupUI _popupUI;

        public Inventory(SlotFactory slotFactory, PopupUI popupUI, IDataPersistentService dataPersistentService)
        {
            _slotFactory = slotFactory;
            _popupUI = popupUI;
             dataPersistentService.AddSaver(this);
            Debug.Log(dataPersistentService.GameData.items.Count);
            for (int i = 0; dataPersistentService.GameData.items.Count > i; i++)
            {
                CreateSlot(dataPersistentService.GameData.items[i]);
            }
        }

        public void Change(IInventorySlot slot)
        {
            _inventory[slot] = slot.CurrentItem;
        }

        public IInventorySlot GetEmptySlot() => _inventory.FirstOrDefault(x => x.Value == null).Key;

        public void SaveData(ref GameData gameData)
        {
            List<IItem> list = _inventory.Values.ToList();
            gameData.items = list;
        }
        private void CreateSlot(IItem item)
        {
            GameObject createdObject = _slotFactory.Create();
            IInventorySlot slot = createdObject.GetComponent<IInventorySlot>();
            _inventory.Add(slot, item);
            slot.Construct(_popupUI, item);
            slot.Changed += Change;
        }

        public void CleanUp()
        {
            foreach (IInventorySlot item in _inventory.Values)
            {
                GameObject.Destroy(item.gameObject);
            }
            _inventory.Clear();
        }
    }
}