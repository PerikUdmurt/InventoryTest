using Inventory.UI;
using System;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public interface IInventorySlot
    {
        GameObject gameObject { get; }
        IItem CurrentItem { get; set; }
        Action<IInventorySlot> Changed { get; set; }

        void Construct(PopupUI popup, IItem item);
        void DropItem();
        void ShowPopup();
        void TakeItem(IItem newItem);
    }
}