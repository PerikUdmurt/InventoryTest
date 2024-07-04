using InventoryTest.Data;
using InventoryTest.Services;
using InventoryTest.Services.SaveLoad;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public class WeaponHUD : MonoBehaviour
    {
        [SerializeField] private int _pistolDamage;
        [SerializeField] private int _rifleDamage;
        [SerializeField] private int _selfDamage;

        private WeaponType _currentWeapon = WeaponType.Pistol;
        private Character _character;
        private Enemy _enemy;

        public void Constuct(Character character, Enemy enemy)
        {
            _character = character;
            _enemy = enemy;
        }

        public void Shoot()
        {
            switch (_currentWeapon)
            {
                case WeaponType.Pistol:
                    _character.health.GetDamage(_selfDamage);
                    _enemy.health.GetDamage(_pistolDamage);
                    return;
                case WeaponType.Rifle:
                    _character.health.GetDamage(_selfDamage);
                    _enemy.health.GetDamage(_rifleDamage);
                    return;
            }
            
        }

        public void ChangeWeapon(int type)
        {
            _currentWeapon = (WeaponType)type;
        }
    }

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
