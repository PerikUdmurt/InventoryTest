using System;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public interface IItem
    {
        public Sprite Sprite { get; }
        public Action Action { get; }
        public string ActionName { get; }

    }
}