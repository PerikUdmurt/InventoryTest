using InventoryTest.Services.SaveLoad;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public class Character : ICharacter
    {
        private readonly GameObject gameOverCanvas;
        public Health health;

        public Character(int health, int maxHealth, GameObject gameOverCanvas)
        {
            this.health = new Health(health, maxHealth);
            this.health.Died += OnDied;
            this.gameOverCanvas = gameOverCanvas;
        }
        public void OnDied()
        {
            gameOverCanvas.SetActive(true);
        }

        public void SaveData(ref GameData gameData)
        {
            gameData.enemyMaxHealth = health.MaxHealth;
            gameData.enemyHealth = health.CurrentHealth;
        }
    }
}
