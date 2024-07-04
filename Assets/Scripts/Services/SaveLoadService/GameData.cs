using InventoryTest.Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest.Services.SaveLoad
{
    [Serializable]
    public class GameData
    {
        public int playerMaxHealth;
        public int playerHealth;
        public int enemyMaxHealth;
        public int enemyHealth;
        public List<IItem> items;

        public GameData() 
        {
            playerHealth = 100;
            playerMaxHealth = 100;
            enemyHealth = 100;
            enemyMaxHealth = 100;
            items = new List<IItem>(30);
            for (int i = 0; i < items.Capacity; i++) items.Add(null);
        }   
    }
}
