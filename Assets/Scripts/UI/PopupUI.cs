using InventoryTest.Gameplay;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class PopupUI : MonoBehaviour, IPopup
    {
        [SerializeField] Image _image;
        [SerializeField] TextMeshProUGUI _specialButtonText;
        private Action _SpecialAction;
        private InventorySlot _currentSlot = null;
        
        public void Show(InventorySlot slot,Action action, string actionName, Sprite sprite)
        {
            _currentSlot = slot;
            _SpecialAction = action;
            _specialButtonText.text = actionName;
            _image.sprite = sprite;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void DropItem()
        {
            _currentSlot.DropItem();
            Hide();
        }

        public void ActivateItem()
        {
            _SpecialAction.Invoke();
        }
    }
}