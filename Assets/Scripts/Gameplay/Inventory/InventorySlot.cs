using Inventory.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventoryTest.Gameplay
{
    public class InventorySlot : MonoBehaviour, IInventorySlot, IPointerClickHandler, IDropHandler, IDragHandler
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
            Debug.Log("Drop");
            _currentItem = null;
            Changed.Invoke(this);
        }

        public void TakeItem(IItem newItem)
        {
            Debug.Log("Take");
            if (newItem == null) return;
            _currentItem = newItem;
            _image.sprite = newItem.Sprite;
            Changed.Invoke(this);
        }

        public void SwapItem(IInventorySlot slot)
        {
            Debug.Log("Swapped");
            slot.TakeItem(CurrentItem);
            TakeItem(slot.CurrentItem);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ShowPopup();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!eventData.rawPointerPress.gameObject.TryGetComponent(out IInventorySlot slot))
            {
                Debug.Log(eventData.rawPointerPress.name);
                return;
            }
            if (_currentItem == null)
            {
                TakeItem(slot.CurrentItem);
                slot.DropItem();
            }
            else
            {
                SwapItem(slot);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}