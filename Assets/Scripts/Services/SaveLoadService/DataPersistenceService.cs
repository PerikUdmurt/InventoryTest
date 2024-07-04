using InventoryTest.Services.FileData;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest.Services.SaveLoad
{
    public class DataPersistenceService : IDataPersistentService
    {
        private GameData gameData;

        private List<IDataSaver> dataSavers = new List<IDataSaver>();

        private FileDataService fileDataService;

        public GameData GameData { get => gameData; }

        public DataPersistenceService()
        {
            fileDataService = new FileDataService(Application.persistentDataPath, "TestData.json");
        }

        public void NewGame()
        {
            gameData = new GameData();
        }

        public void LoadGame()
        {
            gameData = fileDataService.Load();
            if (gameData == null)
            {
                Debug.Log("Игровые данные не найдены. Созданы новые игровые данные");
                NewGame();
            }
        }

        public void SaveGame()
        {
            foreach (IDataSaver saver in dataSavers)
            {
                saver.SaveData(ref gameData);
            }
            fileDataService.Save(gameData);
        }

        public void AddSaver(IDataSaver saver)
        {
            dataSavers.Add(saver);
        }
    }

    public interface IDataSaver
    {
        void SaveData(ref GameData gameData);
    }
}
