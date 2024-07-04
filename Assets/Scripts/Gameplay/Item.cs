using InventoryTest.Data;
using InventoryTest.Services.StaticData;
using System;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public class Item: MonoBehaviour, IItem
    {
        private const string actionName = "Активировать";
        private Sprite _sprite;

        public int CurrentNum { get; private set; }
        public int MaxStack { get; private set; }
        public Sprite Sprite { get => _sprite; }
        public Action Action => Activate;

        public string ActionName => actionName;

        public void Construct()
        {

        }
        public void Activate()
        {
            Debug.Log("Activated");
        }
    }

    public class Equipment : IEquipment
    {
        private const string actionName = "Экипировать";
        private Sprite _sprite;
        public Sprite Sprite { get => _sprite; }

        public Action Action => Equip;

        public string ActionName => actionName;

        private void Equip()
        {

        }
    }

    public interface IEquipment : IItem
    {

    }
}