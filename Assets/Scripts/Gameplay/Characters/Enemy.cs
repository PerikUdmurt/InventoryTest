using InventoryTest.Services;
using InventoryTest.Services.SaveLoad;

namespace InventoryTest.Gameplay
{
    public class Enemy : ICharacter
    {
        public Health health;
        private readonly LootService lootService;

        public Enemy(int health, int maxHealth, LootService lootService)
        {
            this.health = new Health(health, maxHealth);
            this.health.Died += OnDied;
            this.lootService = lootService;
        }

        public void OnDied()
        {
            lootService.GiveRandomLoot();
            CreateNewEnemy();
        }

        private void CreateNewEnemy()
        {
            health.CurrentHealth = int.MaxValue;
        }

        public void SaveData(ref GameData gameData)
        {
            gameData.enemyMaxHealth = health.MaxHealth;
            gameData.enemyHealth = health.CurrentHealth;
        }
    }
}
