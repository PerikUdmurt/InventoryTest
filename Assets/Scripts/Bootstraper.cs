using UnityEngine;
using InventoryTest.Infrastructure.Factory;
using Inventory.UI;
using InventoryTest.Services.StaticData;
using InventoryTest.Services.SaveLoad;
using InventoryTest.Services;
using InventoryTest.UI.ProgressBar;

namespace InventoryTest.Gameplay
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private Transform _inventoryTransform;
        [SerializeField] private PopupUI _popupUI;
        [SerializeField] private WeaponHUD _weaponHUD;
        [SerializeField] private ProgressBarUI _playerProgressBar;
        [SerializeField] private ProgressBarUI _enemyProgressBar;
        [SerializeField] private GameObject GameOverCanvas;

        private StaticDataService _staticDataService;
        private IDataPersistentService _dataPersistentService;
        private Character _player;
        private Enemy _enemy;
        private LootService _lootService;

        void Awake()
        {
            RegisterServices();
            LoadStaticDatas();
            CreateCharacters();
            RegisterHUD();
        }

        public void Restart()
        {
            GameOverCanvas.SetActive(false);
            NewGame();
            CreateCharacters();
            RegisterHUD();
        }

        private void RegisterServices()
        {
            _dataPersistentService = new DataPersistenceService();
            LoadGameData();
            _staticDataService = new StaticDataService();
            SlotFactory slotFactory = new SlotFactory(_inventoryTransform);
            Inventory inventory = new Inventory(slotFactory, _popupUI, _dataPersistentService);
            _lootService = new LootService(inventory);
        }

        private void LoadStaticDatas()
        {
            _staticDataService.LoadStaticDatas();
        }

        private void LoadGameData()
        {
            _dataPersistentService.LoadGame();
        }

        private void NewGame()
        {
            _dataPersistentService.NewGame();
        }

        private void RegisterHUD()
        {
            _weaponHUD.Constuct(_player, _enemy);
            _player.health.HealthChanged += _playerProgressBar.SetValue;
            _enemy.health.HealthChanged += _enemyProgressBar.SetValue;
            _playerProgressBar.SetValue((float)_player.health.CurrentHealth/_player.health.MaxHealth);
            _enemyProgressBar.SetValue((float)_enemy.health.CurrentHealth / _enemy.health.MaxHealth);
        }

        private void CreateCharacters()
        {
            GameData data = _dataPersistentService.GameData;
            _player = new(data.playerHealth, data.playerMaxHealth, GameOverCanvas);
            _enemy = new(data.enemyHealth, data.enemyMaxHealth, _lootService);
            _dataPersistentService.AddSaver(_enemy);
            _dataPersistentService.AddSaver(_player);
        }
    }
}
