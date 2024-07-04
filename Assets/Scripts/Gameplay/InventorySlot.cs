using Inventory.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryTest.Gameplay
{
    public class InventorySlot : MonoBehaviour, IInventorySlot
    {
        [SerializeField] private Image _image;
        private IItem _currentItem = null;
        private PopupUI _popup;
        public void Construct(PopupUI popup, IItem item)
        {
            _popup = popup;
            TakeItem(item);
        }

        public IItem CurrentItem
        {
            get => _currentItem;
            set => _currentItem = value;
        }

        public Action<IInventorySlot> Changed { get; set; }
        GameObject IInventorySlot.gameObject {get => gameObject; }

        public void ShowPopup()
        {
            if (_currentItem == null) return;
            _popup?.Show(this, _currentItem.Action, _currentItem.ActionName, _currentItem.Sprite);
        }

        public void DropItem()
        {
            _currentItem = null;
            Changed.Invoke(this);
        }

        public void TakeItem(IItem newItem)
        {
            if (newItem == null) return;
            _currentItem = newItem;
            _image.sprite = newItem.Sprite;
            Changed.Invoke(this);
        }
    }
}