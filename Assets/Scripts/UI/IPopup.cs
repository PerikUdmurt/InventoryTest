using InventoryTest.Gameplay;
using System;
using UnityEngine;

namespace Inventory.UI
{
    internal interface IPopup
    {
        void ActivateItem();
        void DropItem();
        void Hide();
        void Show(InventorySlot slot, Action action, string actionName, Sprite sprite);
    }
}