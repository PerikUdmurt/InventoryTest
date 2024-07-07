using InventoryTest.Data;
using System;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public abstract class Item: IItem
    {
        protected string _currentID;
        protected Sprite _sprite;
        public int CurrentNum { get; protected set; }
        public int MaxStack { get; protected set; }
        public Sprite Sprite { get => _sprite; }
        public Action Action => Activate;
        public virtual string ActionName => "Активировать";
        protected abstract void Activate();
    }

    public class Equipment : Item, IEquipment
    {
        private int _defense;
        private EquipmentType _equipmentType;
        public EquipmentType EquipmentType { get => _equipmentType; }
        public int Defense { get => _defense; }
        public override string ActionName => "Экипировать";

        public Equipment()
        {

        }

        protected override void Activate()
        {
            
        }
    }

    public class Ammo : IAmmo
    {
        private const string actionName = "Купить";
        private WeaponType _weaponType;
    
        public WeaponType WeaponType => _weaponType;
    }

    public class HealthPoint: IHealthPoition
    {
        private const string actionName = "Лечиться";
        private Sprite _sprite;
        private int _healpoints;

        public Sprite Sprite { get => _sprite; }
        public Action Action => Heal;
        public string ActionName => actionName;
        public int HealPoints => _healpoints;

        private void Heal()
        {

        }
    }

    public interface IEquipment
    {
        int Defense { get; }
        EquipmentType EquipmentType { get; }
    }

    public interface IAmmo
    { 
        WeaponType WeaponType { get; }
    }

    public interface IHealthPoition
    {
        int HealPoints { get; }
    }
}